namespace IconTintIssuesPOC.Helpers;

using CommunityToolkit.Maui.Behaviors;

public static class IconTintColor
{
    public static readonly BindableProperty TintColorProperty =
        BindableProperty.CreateAttached("TintColor",
                                        typeof(Color),
                                        typeof(IconTintColor),
                                        default,
                                        propertyChanged: OnTintColorChanged);

    private static void OnTintColorChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is not View view)
        {
            return;
        }

        if (view.Behaviors.OfType<IconTintColorBehavior>().FirstOrDefault() is { } existing)
        {
            existing.TintColor = (Color)newValue;
        }
        else
        {
            IconTintColorBehavior behavior = new()
            {
                TintColor = (Color)newValue
            };
            view.Behaviors.Add(behavior);
        }
    }

    public static Thickness GetTintColor(BindableObject view)
    {
        return (Thickness)view.GetValue(TintColorProperty);
    }

    public static void SetTintColor(BindableObject view, bool value)
    {
        view.SetValue(TintColorProperty, value);
    }
}
