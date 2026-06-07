using System;
using DG.Tweening.Core;
using UnityEngine;

namespace DG.Tweening.Timeline.Core.Plugins
{
	public class PlugDataGlobalTween : ITweenPluginData, IPluginData
	{
		private readonly DOGetter<float> _floatGetter;

		private readonly DOSetter<float> _floatSetter;

		private readonly DOGetter<int> _intGetter;

		private readonly DOSetter<int> _intSetter;

		private readonly DOGetter<uint> _uintGetter;

		private readonly DOSetter<uint> _uintSetter;

		private readonly DOGetter<string> _stringGetter;

		private readonly DOSetter<string> _stringSetter;

		private readonly DOGetter<Vector2> _vector2Getter;

		private readonly DOSetter<Vector2> _vector2Setter;

		private readonly DOGetter<Vector3> _vector3Getter;

		private readonly DOSetter<Vector3> _vector3Setter;

		private readonly DOGetter<Vector4> _vector4Getter;

		private readonly DOSetter<Vector4> _vector4Setter;

		private readonly DOGetter<Quaternion> _quaternionGetter;

		private readonly DOSetter<Quaternion> _quaternionSetter;

		private readonly DOGetter<Color> _colorGetter;

		private readonly DOSetter<Color> _colorSetter;

		private readonly DOGetter<Rect> _rectGetter;

		private readonly DOSetter<Rect> _rectSetter;

		public bool wantsTarget => false;

		public string guid { get; private set; }

		public string label { get; private set; }

		public string targetLabel => null;

		public string stringOptionLabel { get; private set; }

		public string intOptionLabel { get; private set; }

		public DOTweenClipElement.PropertyType propertyType { get; private set; }

		public PluginTweenType tweenType { get; private set; }

		public Action<object, string, int> onCreation { get; }

		public PlugDataGlobalTween(string guid, string label, DOGetter<float> getter, DOSetter<float> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<int> getter, DOSetter<int> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<uint> getter, DOSetter<uint> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<string> getter, DOSetter<string> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<Vector2> getter, DOSetter<Vector2> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<Vector3> getter, DOSetter<Vector3> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<Vector4> getter, DOSetter<Vector4> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<Quaternion> getter, DOSetter<Quaternion> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<Color> getter, DOSetter<Color> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
		{
		}

		public PlugDataGlobalTween(string guid, string label, DOGetter<Rect> getter, DOSetter<Rect> setter, PluginTweenType tweenType = PluginTweenType.SelfDetermined, Action<object, string, int> onCreation = null)
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
