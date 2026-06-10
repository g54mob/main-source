using UnityEngine;

namespace NSMedieval.Construction.PreviewGridRulers
{
	public class BuildingPreviewGridRuler : MonoBehaviour
	{
		[SerializeField]
		private GameObject topGridParent;

		[SerializeField]
		private GameObject sideGridParent;

		[SerializeField]
		private GameObject dragGridParent;

		[SerializeField]
		private GameObject linePositiveX;

		[SerializeField]
		private GameObject lineNegativeX;

		[SerializeField]
		private GameObject linePositiveZ;

		[SerializeField]
		private GameObject lineNegativeZ;

		public void SetActiveLines(bool active)
		{
			linePositiveX.SetActive(active);
			lineNegativeX.SetActive(active);
			linePositiveZ.SetActive(active);
			lineNegativeZ.SetActive(active);
		}

		public void ResetDrag()
		{
			Vector3 position = linePositiveX.transform.position;
			position = new Vector3(0.5f, position.y, position.z);
			linePositiveX.transform.position = position;
			Vector3 position2 = lineNegativeX.transform.position;
			position2 = new Vector3(-0.5f, position2.y, position2.z);
			lineNegativeX.transform.position = position2;
			Vector3 position3 = linePositiveZ.transform.position;
			position3 = new Vector3(position3.x, position3.y, 0.5f);
			linePositiveZ.transform.position = position3;
			Vector3 position4 = lineNegativeZ.transform.position;
			position4 = new Vector3(position4.x, position4.y, -0.5f);
			lineNegativeZ.transform.position = position4;
			SetActiveLines(active: false);
		}

		public void DragAdjust(float minX, float maxX, float minZ, float maxZ)
		{
			Vector3 position = linePositiveX.transform.position;
			position = new Vector3(maxX + 0.5f, position.y, position.z);
			linePositiveX.transform.position = position;
			Vector3 position2 = lineNegativeX.transform.position;
			position2 = new Vector3(minX - 0.5f, position2.y, position2.z);
			lineNegativeX.transform.position = position2;
			Vector3 position3 = linePositiveZ.transform.position;
			position3 = new Vector3(position3.x, position3.y, maxZ + 0.5f);
			linePositiveZ.transform.position = position3;
			Vector3 position4 = lineNegativeZ.transform.position;
			position4 = new Vector3(position4.x, position4.y, minZ - 0.5f);
			lineNegativeZ.transform.position = position4;
		}

		public void EnableTopGrid()
		{
			if (!topGridParent.activeSelf)
			{
				topGridParent.SetActive(value: true);
				sideGridParent.SetActive(value: false);
				if (dragGridParent.activeSelf)
				{
					ResetDrag();
					dragGridParent.SetActive(value: false);
				}
			}
		}

		public void EnableSideGrid(ObjectSide hitSide)
		{
			if (sideGridParent.activeSelf)
			{
				switch (hitSide)
				{
				case ObjectSide.Front:
					sideGridParent.transform.eulerAngles = Vector3.zero;
					break;
				case ObjectSide.Right:
					sideGridParent.transform.eulerAngles = new Vector3(0f, 90f, 0f);
					break;
				case ObjectSide.Left:
					sideGridParent.transform.eulerAngles = new Vector3(0f, 270f, 0f);
					break;
				default:
					sideGridParent.transform.eulerAngles = new Vector3(0f, 180f, 0f);
					break;
				}
			}
			else
			{
				sideGridParent.SetActive(value: true);
				topGridParent.SetActive(value: false);
				if (dragGridParent.activeSelf)
				{
					ResetDrag();
					dragGridParent.SetActive(value: false);
				}
			}
		}

		public void EnableDragGrid()
		{
			if (!dragGridParent.activeSelf)
			{
				SetActiveLines(active: true);
				dragGridParent.SetActive(value: true);
				topGridParent.SetActive(value: false);
				sideGridParent.SetActive(value: false);
			}
		}

		public void ResetRulers()
		{
			dragGridParent.SetActive(value: false);
			topGridParent.SetActive(value: false);
			sideGridParent.SetActive(value: false);
			SetActiveLines(active: false);
		}
	}
}
