using System;

namespace VRM
{
	public static class VRMBlendShapeProxyExtensions
	{
		[Obsolete("Use BlendShapeKey.CreateFromPreset")]
		public static float GetValue(this VRMBlendShapeProxy proxy, BlendShapePreset key)
		{
			return proxy.GetValue(BlendShapeKey.CreateFromPreset(key));
		}

		[Obsolete("Use BlendShapeKey.CreateUnknown")]
		public static float GetValue(this VRMBlendShapeProxy proxy, string key)
		{
			return proxy.GetValue(BlendShapeKey.CreateUnknown(key));
		}

		[Obsolete("Use ImmediatelySetValue")]
		public static void SetValue(this VRMBlendShapeProxy proxy, BlendShapePreset key, float value)
		{
			proxy.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(key), value);
		}

		[Obsolete("Use BlendShapeKey.CreateFromPreset")]
		public static void ImmediatelySetValue(this VRMBlendShapeProxy proxy, BlendShapePreset key, float value)
		{
			proxy.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(key), value);
		}

		[Obsolete("Use BlendShapeKey.CreateFromPreset")]
		public static void AccumulateValue(this VRMBlendShapeProxy proxy, BlendShapePreset key, float value)
		{
			proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(key), value);
		}

		[Obsolete("Use ImmediatelySetValue")]
		public static void SetValue(this VRMBlendShapeProxy proxy, string key, float value)
		{
			proxy.ImmediatelySetValue(BlendShapeKey.CreateUnknown(key), value);
		}

		[Obsolete("Use BlendShapeKey.CreateUnknown")]
		public static void ImmediatelySetValue(this VRMBlendShapeProxy proxy, string key, float value)
		{
			proxy.ImmediatelySetValue(BlendShapeKey.CreateUnknown(key), value);
		}

		[Obsolete("Use BlendShapeKey.CreateUnknown")]
		public static void AccumulateValue(this VRMBlendShapeProxy proxy, string key, float value)
		{
			proxy.AccumulateValue(BlendShapeKey.CreateUnknown(key), value);
		}

		[Obsolete("Use ImmediatelySetValue")]
		public static void SetValue(this VRMBlendShapeProxy proxy, BlendShapeKey key, float value)
		{
			proxy.ImmediatelySetValue(key, value);
		}

		[Obsolete("Use ImmediatelySetValue or AccumulateValue")]
		public static void SetValue(this VRMBlendShapeProxy proxy, BlendShapePreset key, float value, bool apply)
		{
			if (apply)
			{
				proxy.ImmediatelySetValue(BlendShapeKey.CreateFromPreset(key), value);
			}
			else
			{
				proxy.AccumulateValue(BlendShapeKey.CreateFromPreset(key), value);
			}
		}

		[Obsolete("Use ImmediatelySetValue or AccumulateValue")]
		public static void SetValue(this VRMBlendShapeProxy proxy, string key, float value, bool apply)
		{
			if (apply)
			{
				proxy.ImmediatelySetValue(BlendShapeKey.CreateUnknown(key), value);
			}
			else
			{
				proxy.AccumulateValue(BlendShapeKey.CreateUnknown(key), value);
			}
		}

		[Obsolete("Use ImmediatelySetValue or AccumulateValue")]
		public static void SetValue(this VRMBlendShapeProxy proxy, BlendShapeKey key, float value, bool apply)
		{
			if (apply)
			{
				proxy.ImmediatelySetValue(key, value);
			}
			else
			{
				proxy.AccumulateValue(key, value);
			}
		}
	}
}
