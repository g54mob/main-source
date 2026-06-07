using UnityEngine;

namespace UMA
{
	public class DNAEffector : MonoBehaviour
	{
		public IDNASelector dNAEffector;

		public string dnaName;

		public void Setup(IDNASelector dNAEffector, string dnaName, string label, float value)
		{
		}

		public void Reset(float value)
		{
		}

		public void DNAChanged(float value)
		{
		}
	}
}
