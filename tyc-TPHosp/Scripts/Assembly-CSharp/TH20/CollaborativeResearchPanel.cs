using System;
using UnityEngine;

namespace TH20
{
	public abstract class CollaborativeResearchPanel : MonoBehaviour
	{
		protected Guid? ProjectId;

		protected CollaborativePortfolio Portfolio;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public void Initialise(CollaborativePortfolio portfolio)
		{
			Portfolio = portfolio;
		}

		public virtual void SetupForProject(Guid? projectId)
		{
			ProjectId = projectId;
		}

		public virtual void Show()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: true);
		}

		public virtual void Hide()
		{
			GameObjectUtils.SetActive(base.gameObject, isActive: false);
		}

		public abstract void OnGetLatestCompleted();
	}
}
