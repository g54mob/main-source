using System;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFAnimationTarget : JsonSerializableBase
	{
		public enum Interpolations
		{
			LINEAR = 0,
			STEP = 1,
			CUBICSPLINE = 2
		}

		[Obsolete("Use AnimationProperties")]
		public enum AnimationPropertys
		{
			Translation = 0,
			EulerRotation = 1,
			Rotation = 2,
			Scale = 3,
			Weight = 4,
			BlendShape = 5,
			NotImplemented = 6
		}

		public enum AnimationProperties
		{
			Translation = 0,
			EulerRotation = 1,
			Rotation = 2,
			Scale = 3,
			Weight = 4,
			BlendShape = 5,
			NotImplemented = 6
		}

		[JsonSchema(Minimum = 0.0)]
		public int node;

		[JsonSchema(Required = true, EnumValues = new object[] { "translation", "rotation", "scale", "weights" }, EnumSerializationType = EnumSerializationType.AsString)]
		public string path;

		public object extensions;

		public object extras;

		public const string PATH_TRANSLATION = "translation";

		public const string PATH_EULER_ROTATION = "rotation";

		public const string PATH_ROTATION = "rotation";

		public const string PATH_SCALE = "scale";

		public const string PATH_WEIGHT = "weights";

		public const string NOT_IMPLEMENTED = "NotImplemented";

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			f.KeyValue(() => node);
			if (!string.IsNullOrEmpty(path))
			{
				f.KeyValue(() => path);
			}
		}

		[Obsolete]
		internal static AnimationProperties AnimationPropertysToAnimationProperties(AnimationPropertys property)
		{
			if (!Enum.IsDefined(typeof(AnimationProperties), property))
			{
				throw new InvalidCastException("Failed to convert AnimationPropertys '" + property.ToString() + "' to AnimationProperties");
			}
			return (AnimationProperties)property;
		}

		[Obsolete]
		public static string GetPathName(AnimationPropertys property)
		{
			return GetPathName(AnimationPropertysToAnimationProperties(property));
		}

		public static string GetPathName(AnimationProperties property)
		{
			switch (property)
			{
			case AnimationProperties.Translation:
				return "translation";
			case AnimationProperties.EulerRotation:
			case AnimationProperties.Rotation:
				return "rotation";
			case AnimationProperties.Scale:
				return "scale";
			case AnimationProperties.BlendShape:
				return "weights";
			default:
				throw new NotImplementedException();
			}
		}

		public static AnimationProperties GetAnimationProperty(string path)
		{
			return path switch
			{
				"translation" => AnimationProperties.Translation, 
				"rotation" => AnimationProperties.Rotation, 
				"scale" => AnimationProperties.Scale, 
				"weights" => AnimationProperties.BlendShape, 
				_ => throw new NotImplementedException(), 
			};
		}

		[Obsolete]
		public static int GetElementCount(AnimationPropertys property)
		{
			return GetElementCount(AnimationPropertysToAnimationProperties(property));
		}

		public static int GetElementCount(AnimationProperties property)
		{
			return property switch
			{
				AnimationProperties.Translation => 3, 
				AnimationProperties.EulerRotation => 3, 
				AnimationProperties.Rotation => 4, 
				AnimationProperties.Scale => 3, 
				AnimationProperties.BlendShape => 1, 
				_ => throw new NotImplementedException(), 
			};
		}

		public static int GetElementCount(string path)
		{
			return GetElementCount(GetAnimationProperty(path));
		}
	}
}
