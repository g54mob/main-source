using TinyGiantStudio.Text.Example;
using UnityEngine;

namespace TinyGiantStudio.Text.SampleScene
{
	public class MText_SampleScene_Cursor : MonoBehaviour
	{
		[SerializeField]
		private Transform crosshair;

		[SerializeField]
		private float rotationSpeed;

		[SerializeField]
		private ParticleSystem hitEffect;

		[SerializeField]
		private StatusToolTip statusToolTip;

		[SerializeField]
		private Camera myCamera;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private bool MouseClicked()
		{
			return false;
		}

		private bool Tapped()
		{
			return false;
		}
	}
}
