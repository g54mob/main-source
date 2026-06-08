using UnityEngine;

namespace GRP
{
	[RequireComponent(typeof(PartView), typeof(CursorPointable))]
	public class PartCursor : MonoBehaviour
	{
		private PartView part;

		private CursorPointable cursor;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void UpdateCursor()
		{
		}
	}
}
