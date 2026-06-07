using UnityEngine;

namespace FIMSpace.RagdollAnimatorDemo
{
	[DefaultExecutionOrder(-100)]
	public class Demo_Ragd_DuplicateAtAwake : FimpossibleComponent
	{
		public int CopiesX = 4;

		public int CopiesZ = 2;

		public float Separation = 2f;

		public GameObject ToCopy;

		private void Awake()
		{
			Duplicate();
		}

		public void Duplicate()
		{
			int num = Mathf.RoundToInt(CopiesX / 2);
			int num2 = Mathf.RoundToInt(CopiesZ / 2);
			for (int i = -num; i <= num; i++)
			{
				for (int j = -num2; j <= num2; j++)
				{
					Object.Instantiate(ToCopy).transform.position = base.transform.position + new Vector3((float)i * Separation, 0f, (float)j * Separation);
				}
			}
			Physics.SyncTransforms();
		}
	}
}
