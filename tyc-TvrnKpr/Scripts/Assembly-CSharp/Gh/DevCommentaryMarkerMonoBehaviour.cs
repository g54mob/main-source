using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public class DevCommentaryMarkerMonoBehaviour : MonoBehaviour
	{
		[SerializeField]
		private string commentaryId;

		public bool isUi;

		[Tooltip("If set, will use this prefab instead of the standard one.")]
		public GameObject prefabOverride;

		private DevCommentaryNode3DUIView _visual;

		private BaseInteractable3DUIView _parent;

		private DevCommentaryMetadata _devCommentaryData;

		public DevCommentaryMetadata DevCommentaryData => null;

		public string CommentaryId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Start()
		{
		}

		public void ShowMarker(bool visible)
		{
		}
	}
}
