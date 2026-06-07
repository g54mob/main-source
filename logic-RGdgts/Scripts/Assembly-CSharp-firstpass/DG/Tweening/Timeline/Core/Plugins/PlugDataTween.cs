using System;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public class PlugDataTween : ITweenPluginData, IPluginData
	{
		private readonly Func<object, string, int, DOGetter<float>> _floatGetterGen;

		private readonly Func<object, string, int, DOSetter<float>> _floatSetterGen;

		private readonly Func<object, string, int, DOGetter<int>> _intGetterGen;

		private readonly Func<object, string, int, DOSetter<int>> _intSetterGen;

		private readonly Func<object, string, int, DOGetter<uint>> _uintGetterGen;

		private readonly Func<object, string, int, DOSetter<uint>> _uintSetterGen;

		private readonly Func<object, string, int, DOGetter<string>> _stringGetterGen;

		private readonly Func<object, string, int, DOSetter<string>> _stringSetterGen;

		private readonly Func<object, string, int, DOGetter<Vector2>> _vector2GetterGen;

		private readonly Func<object, string, int, DOSetter<Vector2>> _vector2SetterGen;

		private readonly Func<object, string, int, DOGetter<Vector3>> _vector3GetterGen;

		private readonly Func<object, string, int, DOSetter<Vector3>> _vector3SetterGen;

		private readonly Func<object, string, int, DOGetter<Vector4>> _vector4GetterGen;

		private readonly Func<object, string, int, DOSetter<Vector4>> _vector4SetterGen;

		private readonly Func<object, string, int, DOGetter<Quaternion>> _quaternionGetterGen;

		private readonly Func<object, string, int, DOSetter<Quaternion>> _quaternionSetterGen;

		private readonly Func<object, string, int, DOGetter<Color>> _colorGetterGen;

		private readonly Func<object, string, int, DOSetter<Color>> _colorSetterGen;

		private readonly Func<object, string, int, DOGetter<Rect>> _rectGetterGen;

		private readonly Func<object, string, int, DOSetter<Rect>> _rectSetterGen;

		public bool wantsTarget => false;

		public string guid { get; private set; }

		public string label { get; private set; }

		public string targetLabel => null;

		public string stringOptionLabel { get; private set; }

		public string intOptionLabel { get; private set; }

		public DOTweenClipElement.PropertyType propertyType { get; private set; }

		public PluginTweenType tweenType { get; private set; }

		public Action<object, string, int> onCreation { get; }

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<float>> getterGen, Func<object, string, int, DOSetter<float>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<int>> getterGen, Func<object, string, int, DOSetter<int>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<uint>> getterGen, Func<object, string, int, DOSetter<uint>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<string>> getterGen, Func<object, string, int, DOSetter<string>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<Vector2>> getterGen, Func<object, string, int, DOSetter<Vector2>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<Vector3>> getterGen, Func<object, string, int, DOSetter<Vector3>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<Vector4>> getterGen, Func<object, string, int, DOSetter<Vector4>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<Quaternion>> getterGen, Func<object, string, int, DOSetter<Quaternion>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<Color>> getterGen, Func<object, string, int, DOSetter<Color>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataTween(string guid, string label, Func<object, string, int, DOGetter<Rect>> getterGen, Func<object, string, int, DOSetter<Rect>> setterGen, PluginTweenType tweenType = PluginTweenType.SelfDetermined, string stringOptionLabel = null, string intOptionLabel = null, Action<object, string, int> onCreation = null)
		{
		}

		public DOGetter<float> FloatGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<float> FloatSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<int> IntGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<int> IntSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<uint> UintGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<uint> UintSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<string> StringGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<string> StringSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<Vector2> Vector2Getter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<Vector2> Vector2Setter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<Vector3> Vector3Getter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<Vector3> Vector3Setter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<Vector4> Vector4Getter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<Vector4> Vector4Setter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<Quaternion> QuaternionGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<Quaternion> QuaternionSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<Color> ColorGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<Color> ColorSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOGetter<Rect> RectGetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}

		public DOSetter<Rect> RectSetter(object target = null, string strVal = null, int intVal = 0)
		{
			return null;
		}
	}
}
