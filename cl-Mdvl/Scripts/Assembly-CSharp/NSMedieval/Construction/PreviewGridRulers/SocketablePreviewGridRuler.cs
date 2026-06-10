using UnityEngine;

namespace NSMedieval.Construction.PreviewGridRulers
{
	public class SocketablePreviewGridRuler : MonoBehaviour
	{
		[SerializeField]
		private GameObject grid;

		public void ShowGrid()
		{
			grid.SetActive(value: true);
		}

		public void HideGrid()
		{
			grid.SetActive(value: false);
		}

		public void SetAngle(ObjectSide hitSide)
		{
			switch (hitSide)
			{
			case ObjectSide.Front:
				grid.transform.eulerAngles = Vector3.zero;
				break;
			case ObjectSide.Right:
				grid.transform.eulerAngles = new Vector3(0f, 90f, 0f);
				break;
			case ObjectSide.Left:
				grid.transform.eulerAngles = new Vector3(0f, 270f, 0f);
				break;
			default:
				grid.transform.eulerAngles = new Vector3(0f, 180f, 0f);
				break;
			}
		}
	}
}
