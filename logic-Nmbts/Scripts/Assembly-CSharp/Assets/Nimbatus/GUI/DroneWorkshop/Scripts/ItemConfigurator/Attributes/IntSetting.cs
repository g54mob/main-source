using System;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts.ItemConfigurator.Attributes
{
	[AttributeUsage(AttributeTargets.Field)]
	public class IntSetting : DronePartSetting
	{
		private readonly int _minValue;

		private readonly int _maxValue;

		private readonly int _steps;

		private readonly bool _hasProperties;

		private readonly string _stepsProperty;

		private readonly string _maxValueProperty;

		private readonly string _minValueProperty;

		public int GetMinValue(object parentObject)
		{
			if (_hasProperties)
			{
				return ReflectionHelper.GetValueFromMethodOrField<int>(parentObject, _minValueProperty);
			}
			return _minValue;
		}

		public int GetMaxValue(object parentObject)
		{
			if (_hasProperties)
			{
				return ReflectionHelper.GetValueFromMethodOrField<int>(parentObject, _maxValueProperty);
			}
			return _maxValue;
		}

		public int GetSteps(object parentObject)
		{
			if (_hasProperties)
			{
				return ReflectionHelper.GetValueFromMethodOrField<int>(parentObject, _stepsProperty);
			}
			return _steps;
		}

		public IntSetting(string term, int minValue, int maxValue, int steps, UndoManager.EStoreReason reason)
			: base(term, reason)
		{
			_minValue = minValue;
			_maxValue = maxValue;
			_steps = steps;
		}

		public IntSetting(string term, string minValueProperty, string maxValueProperty, string stepsProperty, UndoManager.EStoreReason reason)
			: base(term, reason)
		{
			_minValueProperty = minValueProperty;
			_maxValueProperty = maxValueProperty;
			_stepsProperty = stepsProperty;
			_hasProperties = true;
		}
	}
}
