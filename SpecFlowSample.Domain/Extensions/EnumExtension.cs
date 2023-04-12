namespace SpecFlowSample.Domain.Extensions;

public static class EnumExtension
{
    public static TEnum GetEnumByName<TEnum>(string valueName) where TEnum : struct, Enum
    {
        if (Enum.TryParse<TEnum>(valueName, out var result))
            return result;
        throw new ArgumentException(valueName);
    }

    public static string? GetStringValue(this Enum value)
    {
        return  Enum.GetName(value.GetType(), value);
    }
}