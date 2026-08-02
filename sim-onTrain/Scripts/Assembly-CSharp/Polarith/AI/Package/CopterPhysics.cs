using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Character/Copter Physics")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-coptercontroller.html")]
	[RequireComponent(typeof(CopterController))]
	public sealed class CopterPhysics : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("The 'Copter Controller' component that will be used to steer the agent.")]
		private CopterController copterController;

		public float Thrust => CopterController.Force.magnitude;

		public CopterController CopterController
		{
			get
			{
				return copterController;
			}
			set
			{
				copterController = value;
			}
		}

		private void Start()
		{
			CopterController = GetComponent<CopterController>();
		}

		private void FixedUpdate()
		{
			Vector3 torque = new Vector3(CopterController.Pitch, CopterController.Yaw, CopterController.Roll) * Time.deltaTime;
			CopterController.Body.AddRelativeTorque(torque);
			CopterController.Body.AddForce(CopterController.Force);
		}
	}
}
