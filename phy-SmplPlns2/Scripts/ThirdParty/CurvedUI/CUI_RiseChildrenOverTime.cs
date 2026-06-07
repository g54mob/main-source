using UnityEngine;

namespace CurvedUI
{
	public class CUI_RiseChildrenOverTime : MonoBehaviour
	{
		private float current;

		public float Speed = 10f;

		public float RiseBy = 50f;

		private void Start()
		{
		}

		private void Update()
		{
			current += Speed * Time.deltaTime;
			if (Mathf.RoundToInt(current) >= base.transform.childCount)
			{
				current = 0f;
			}
			if (Mathf.RoundToInt(current) < 0)
			{
				current = base.transform.childCount - 1;
			}
			for (int i = 0; i < base.transform.childCount; i++)
			{
				if (Mathf.RoundToInt(current) == i)
				{
					base.transform.GetChild(i).localPosition = base.transform.GetChild(i).localPosition.ModifyZ(0f - RiseBy);
				}
				else
				{
					base.transform.GetChild(i).localPosition = base.transform.GetChild(i).localPosition.ModifyZ(0f);
				}
			}
		}
	}
}
