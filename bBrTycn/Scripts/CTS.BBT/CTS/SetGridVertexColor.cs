using UnityEngine;

namespace CTS
{
	public class SetGridVertexColor : MonoBehaviour
	{
		[SerializeField]
		private bool _xPlus;

		[SerializeField]
		private bool _xMinus;

		[SerializeField]
		private bool _zPlus;

		[SerializeField]
		private bool _zMinus;

		private static readonly Color _transColor = new Color(1f, 1f, 1f, 0f);

		private static readonly Color _opaqueColor = Color.white;

		private void Awake()
		{
			SetEnds(_xPlus, _xMinus, _zPlus, _zMinus);
		}

		public void SetEnds(bool xPlus, bool xMinus, bool zPlus, bool zMinus)
		{
			MeshFilter component = GetComponent<MeshFilter>();
			Color[] colors = new Color[4]
			{
				(zPlus || xPlus) ? _transColor : _opaqueColor,
				(zMinus || xPlus) ? _transColor : _opaqueColor,
				(zMinus || xMinus) ? _transColor : _opaqueColor,
				(zPlus || xMinus) ? _transColor : _opaqueColor
			};
			component.mesh.colors = colors;
		}
	}
}
