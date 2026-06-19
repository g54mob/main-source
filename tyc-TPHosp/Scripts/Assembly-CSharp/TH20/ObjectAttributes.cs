using JetBrains.Annotations;

namespace TH20
{
	public class ObjectAttributes : Attributes
	{
		public enum Type
		{
			None = -1,
			Maintenance = 0
		}

		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Definition
		{
			public Type _type;

			public float _initialValue;
		}

		public static string[] TypeNames = new string[1] { "Maintenance" };

		public static int[] TypeHashCodes = new int[1] { "Maintenance".GetHashCode() };

		public ObjectAttributes(IAttributesInterface owner)
			: base(owner, TypeNames)
		{
		}

		public void Add(Type type, AttributeFloat attribute)
		{
			Add((int)type, attribute);
		}

		public AttributeFloat GetAttribute(Type type)
		{
			return GetAttribute((int)type);
		}
	}
}
