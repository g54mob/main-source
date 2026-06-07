using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class BuildVariantElement : MonoBehaviour
	{
		[DropDownChoice(typeof(GameFlags), "GetVariantSymbols")]
		public string[] variants;

		public bool includeInVariant;

		private void Awake()
		{
		}

		public void UpdateState()
		{
		}

		public static void UpdateState(GameObject gameObject)
		{
		}
	}
}
