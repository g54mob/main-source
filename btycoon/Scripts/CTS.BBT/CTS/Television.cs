using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace CTS
{
	public class Television : FurnitureInteractor, IContextActor
	{
		[SerializeField]
		private float _interval = 5f;

		[SerializeField]
		private float _detectionRadius = 5f;

		[SerializeField]
		[Foldout("Dev")]
		private LayerMask _agentLayer;

		[SerializeField]
		private float _funToWin = 15f;

		[SerializeField]
		private float _funToWinVampires = 15f;

		[SerializeField]
		[Foldout("Dev")]
		private VideoPlayer _videoPlayer;

		[SerializeField]
		[Foldout("Dev")]
		private RawImage _image;

		[Inject(false)]
		private Furniture _furniture;

		[field: SerializeField]
		[field: Foldout("Dev")]
		public bool IsActive { get; private set; }

		[field: SerializeField]
		[field: Foldout("Dev")]
		public ContextActorData ContextActorData { get; private set; }

		private void Start()
		{
			_videoPlayer.Play();
			_image.enabled = true;
			IsActive = true;
			StartCoroutine(GenerateSphereAndIncreaseFun());
		}

		public void SetActive(bool active)
		{
			IsActive = active;
			if (IsActive)
			{
				_videoPlayer.Play();
				StartCoroutine(GenerateSphereAndIncreaseFun());
			}
			else
			{
				_videoPlayer.Stop();
				StopAllCoroutines();
			}
			_image.enabled = IsActive;
		}

		private IEnumerator GenerateSphereAndIncreaseFun()
		{
			while (IsActive)
			{
				yield return Coroutines.WaitForSeconds(_interval / 2f);
				CheckAgentInside();
				yield return Coroutines.WaitForSeconds(_interval / 2f);
			}
		}

		[Button(null, EButtonEnableMode.Always)]
		private void CheckAgentInside()
		{
			Collider[] array = PhysicsAllocation.Get(20);
			int num = Physics.OverlapSphereNonAlloc(base.transform.position, _detectionRadius, array, _agentLayer);
			RoomBuilding currentRoom = _furniture.RoomObject.CurrentRoom;
			for (int i = 0; i < num; i++)
			{
				Agent componentInParent = array[i].transform.GetComponentInParent<Agent>();
				if ((object)componentInParent != null && (object)componentInParent.RoomObject.CurrentRoom == currentRoom)
				{
					if (componentInParent.IsHuman)
					{
						componentInParent.Statistics.AddToStatistic(EAgentStatistics.Fun, _funToWin);
					}
					else
					{
						componentInParent.Statistics.AddToStatistic(EAgentStatistics.Fun, _funToWinVampires);
					}
				}
			}
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(base.transform.position, _detectionRadius);
		}
	}
}
