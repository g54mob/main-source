using System;

namespace Moq
{
	internal sealed class MockDefaultValueProvider : LookupOrFallbackDefaultValueProvider
	{
		internal override DefaultValue Kind => DefaultValue.Mock;

		internal MockDefaultValueProvider()
		{
		}

		protected override object GetFallbackDefaultValue(Type type, Mock mock)
		{
			object defaultValue = DefaultValueProvider.Empty.GetDefaultValue(type, mock);
			if (defaultValue != null)
			{
				return defaultValue;
			}
			if (type.IsMockable())
			{
				Type type2 = typeof(Mock<>).MakeGenericType(type);
				Mock mock2 = (Mock)Activator.CreateInstance(type2, mock.Behavior);
				mock2.DefaultValueProvider = mock.DefaultValueProvider;
				if (mock.MutableSetups.FindLast((Setup s) => s is StubbedPropertiesSetup) is StubbedPropertiesSetup stubbedPropertiesSetup)
				{
					mock2.MutableSetups.Add(new StubbedPropertiesSetup(mock2, stubbedPropertiesSetup.DefaultValueProvider));
				}
				if (!type.IsDelegateType())
				{
					mock2.CallBase = mock.CallBase;
				}
				mock2.Switches = mock.Switches;
				return mock2.Object;
			}
			return null;
		}
	}
}
