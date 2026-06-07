using System;
using System.Threading.Tasks;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.VisualScripting
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/visual-scripting/conditions")]
	[AddComponentMenu("Game Creator/Visual Scripting/Conditions")]
	[DefaultExecutionOrder(1)]
	public class Conditions : MonoBehaviour
	{
		[SerializeField]
		protected BranchList m_Branches = new BranchList();

		private Args m_Args;

		public bool IsRunning => m_Branches.IsRunning;

		public event Action EventStartRunning;

		public event Action EventEndRunning;

		public void Invoke(GameObject self = null)
		{
			Args args = new Args((self != null) ? self : base.gameObject, base.gameObject);
			Run(args);
		}

		public async Task Run()
		{
			if (m_Args == null)
			{
				m_Args = new Args(base.gameObject);
			}
			await Run(m_Args);
		}

		public async Task Run(Args args)
		{
			this.EventStartRunning?.Invoke();
			await m_Branches.Evaluate(args);
			this.EventEndRunning?.Invoke();
		}

		public void Cancel()
		{
			m_Branches.Cancel();
		}
	}
}
