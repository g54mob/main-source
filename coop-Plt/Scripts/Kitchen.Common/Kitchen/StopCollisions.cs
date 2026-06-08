using UnityEngine;

namespace Kitchen
{
	public class StopCollisions : GenericObjectView
	{
		[Header("Configuration")]
		[SerializeField]
		private LayerMask Layer1;

		[SerializeField]
		private LayerMask Layer2;

		public override void Initialise()
		{
			base.Initialise();
			Physics.IgnoreLayerCollision((int)Mathf.Log(Layer1.value, 2f), (int)Mathf.Log(Layer2.value, 2f), ignore: true);
		}

		public override void Remove()
		{
			Physics.IgnoreLayerCollision((int)Mathf.Log(Layer1.value, 2f), (int)Mathf.Log(Layer2.value, 2f), ignore: false);
			base.Remove();
		}
	}
}
