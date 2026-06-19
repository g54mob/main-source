using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "<FuelItems>k__BackingField", "ItemPortionSpent" })]
	public class ES3UserType_CrafterFueler : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_CrafterFueler()
			: base(null)
		{
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
		}
	}
}
