using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	public class DistanceFieldSettings : BaseMeshEffect
	{
		[SerializeField]
		private float _cutoff;

		[SerializeField]
		private float _outline;

		[SerializeField]
		private float _shadow;

		[SerializeField]
		private float _fill;

		public float cutoff
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float outline
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float shadow
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float fill
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void SetDirty()
		{
		}

		public override void ModifyMesh(VertexHelper vh)
		{
		}

		private void NameAfterSprite()
		{
		}
	}
}
