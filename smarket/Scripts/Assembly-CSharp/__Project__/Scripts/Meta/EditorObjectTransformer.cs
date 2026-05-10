using System.Collections.Generic;
using UnityEngine;

namespace __Project__.Scripts.Meta
{
	public class EditorObjectTransformer : MonoBehaviour
	{
		[SerializeField]
		private List<GameObject> m_ObjectsToCopy;

		[SerializeField]
		private List<GameObject> m_ObjectsToPaste;

		[Tooltip("Use only for editor. sets all paintable floors")]
		public void CopyObjectTransforms()
		{
		}
	}
}
