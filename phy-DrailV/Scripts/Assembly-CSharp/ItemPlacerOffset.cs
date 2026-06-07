using UnityEngine;

public class ItemPlacerOffset : MonoBehaviour
{
	public struct ItemPlacerOffsetData
	{
		private const string PAPER_NAME = "Paper";

		public readonly float thicknessOffset;

		public readonly Vector3 scaleOffset;

		public readonly float heightOffset;

		public readonly Quaternion rotationOffset;

		public readonly bool invertScrolling;

		public ItemPlacerOffsetData(GameObject go, Quaternion rotationOffset, float heightOffset, bool invertScrolling)
		{
			if (go == null)
			{
				thicknessOffset = 0f;
				scaleOffset = default(Vector3);
				this.heightOffset = 0f;
				this.rotationOffset = default(Quaternion);
				this.invertScrolling = false;
				Debug.LogError("ItemPlacerOffsetData is missing a valid GameObject reference. All values will be default.");
				return;
			}
			this.heightOffset = heightOffset;
			this.rotationOffset = rotationOffset;
			bool flag = false;
			if (go.GetComponent<PageBook>() != null || (bool)go.GetComponentInChildren<Page>(includeInactive: true))
			{
				flag = true;
			}
			else
			{
				Transform transform = go.transform.Find("Paper");
				flag = transform != null && go.transform != transform;
			}
			if (flag)
			{
				BoxCollider componentInChildren = go.GetComponentInChildren<BoxCollider>();
				if (componentInChildren != null)
				{
					thicknessOffset = componentInChildren.size.y;
				}
				else
				{
					thicknessOffset = 0f;
					Debug.LogError("GameObject doesn't have a box collier. Check hierarchy!", go);
				}
				Page componentInChildren2 = go.GetComponentInChildren<Page>(includeInactive: true);
				if (componentInChildren2 != null)
				{
					scaleOffset = componentInChildren2.transform.localScale;
					scaleOffset.y = 1f;
				}
				else
				{
					scaleOffset = default(Vector3);
				}
			}
			else
			{
				thicknessOffset = 0f;
				scaleOffset = default(Vector3);
			}
			this.invertScrolling = invertScrolling;
		}

		public ItemPlacerOffsetData(GameObject go)
			: this(go, Quaternion.identity, 0f, invertScrolling: false)
		{
		}
	}

	[SerializeField]
	private Vector3 customRotationOffset;

	[SerializeField]
	private float customHeightOffset;

	[SerializeField]
	private bool invertPlacementScrolling;

	private PageBook pageBook;

	public ItemPlacerOffsetData OffsetData { get; private set; }

	private void Start()
	{
		if (VRManager.IsVREnabled())
		{
			Object.Destroy(this);
			return;
		}
		pageBook = GetComponent<PageBook>();
		if (pageBook != null && pageBook.autoColliderThickness && !pageBook.PagesGenerated)
		{
			pageBook.PageBookGenerated += OnPageBookGenerated;
		}
		else
		{
			GenerateOffsetData();
		}
	}

	private void OnDestroy()
	{
		if (pageBook != null)
		{
			pageBook.PageBookGenerated -= OnPageBookGenerated;
		}
	}

	private void GenerateOffsetData()
	{
		Quaternion rotationOffset = Quaternion.Euler(customRotationOffset);
		OffsetData = new ItemPlacerOffsetData(base.gameObject, rotationOffset, customHeightOffset, invertPlacementScrolling);
	}

	private void OnPageBookGenerated()
	{
		GenerateOffsetData();
		pageBook.PageBookGenerated -= OnPageBookGenerated;
	}
}
