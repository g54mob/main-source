using UnityEngine;

namespace UnityMeshSimplifier
{
	[AddComponentMenu(null)]
	public class LODBackupComponent : MonoBehaviour
	{
		[SerializeField]
		private Renderer[] originalRenderers;

		[SerializeField]
		public GameObject lodParentObject;

		public Renderer[] OriginalRenderers
		{
			get
			{
				return null;
			}
			set
			{
			}
		}
	}
}
