using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public class BE2_BlockSectionHeader_ReferenceInput : MonoBehaviour, I_BE2_BlockSectionHeaderInput
	{
		public I_BE2_BlockSectionHeaderInput referenceInput;

		public Transform Transform => base.transform;

		public I_BE2_Spot Spot { get; }

		public float FloatValue => referenceInput.FloatValue;

		public string StringValue => referenceInput.StringValue;

		public BE2_InputValues InputValues => referenceInput.InputValues;

		public void UpdateValues()
		{
		}
	}
}
