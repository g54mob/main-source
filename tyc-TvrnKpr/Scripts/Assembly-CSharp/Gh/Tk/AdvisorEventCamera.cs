using LitJson;
using UnityEngine;

namespace Gh.Tk
{
	public class AdvisorEventCamera : SceneEventCamera
	{
		[JsonIgnore]
		public Animator _advisorAnimator;

		[PersistenceOptIn]
		public AdvisorState advisorState;

		protected override void Start()
		{
		}

		private void SetAdvisorState(AdvisorState state)
		{
		}
	}
}
