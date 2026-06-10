using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Scripts.Pooler;
using UnityEngine;

namespace NSMedieval
{
	public class BasicPointToPointMove : MonoBehaviour
	{
		private Vector3 logicalPosition;

		private float speed;

		private bool isDestinationSet;

		private Vector3 destination;

		private Transform transformDestination;

		private Vector3 destinationOffset;

		private bool dontSpawnEffectOnTarget;

		private Vector3? onHitParticlePositionOverride;

		private Vector3 bezierInitialPos;

		private Vector3 bezierApex;

		private float destroyDelay;

		private float canDestroyAfterTimestamp;

		private string particlesOnHit;

		public Vector3 OffsetDestination
		{
			get
			{
				if (!(transformDestination != null))
				{
					return destination + destinationOffset;
				}
				return transformDestination.position + destinationOffset;
			}
		}

		public event Action DestinationReachedEvent;

		public void SetParticlesOhHit(string particlesOnHit)
		{
			this.particlesOnHit = particlesOnHit;
		}

		public void OverrideParticleOnHitPosition(Vector3 position)
		{
			onHitParticlePositionOverride = position;
		}

		public void Setup(Vector3 destination, float speed, bool dontSpawnEffect, Vector3 destinationOffset, float arrowBezierPathApex, float destroyDelay = 0f)
		{
			this.destination = destination;
			this.speed = speed;
			isDestinationSet = true;
			dontSpawnEffectOnTarget = dontSpawnEffect;
			this.destinationOffset = destinationOffset;
			this.destroyDelay = destroyDelay;
			canDestroyAfterTimestamp = 0f;
			logicalPosition = base.transform.position;
			bezierInitialPos = logicalPosition;
			Vector3 vector = (bezierInitialPos + OffsetDestination) / 2f;
			base.transform.LookAt(OffsetDestination);
			Vector3 up = base.transform.up;
			bezierApex = vector + up * arrowBezierPathApex;
		}

		public void Setup(Transform destination, float speed, bool dontSpawnEffect, Vector3 destinationOffset, float arrowBezierPathApex, float destroyDelay = 0f)
		{
			if (!(destination == null))
			{
				transformDestination = destination;
				Setup(destination.position, speed, dontSpawnEffect, destinationOffset, arrowBezierPathApex, destroyDelay);
			}
		}

		private void Update()
		{
			if (LoadingController.IsSceneTransition)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			else if (!isDestinationSet)
			{
				if (Time.time > canDestroyAfterTimestamp)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else
			{
				if (Time.deltaTime <= 0f)
				{
					return;
				}
				if (transformDestination != null)
				{
					destination = transformDestination.position;
				}
				logicalPosition = Vector3.MoveTowards(logicalPosition, OffsetDestination, Time.deltaTime * speed);
				Transform obj = base.transform;
				Vector3 position = obj.position;
				Vector3 vector = BezierPath.EvaluateQuadratic(t: (logicalPosition - bezierInitialPos).magnitude / (OffsetDestination - bezierInitialPos).magnitude, p0: bezierInitialPos, p1: bezierApex, p2: OffsetDestination);
				Vector3 normalized = (vector - position).normalized;
				obj.forward = normalized;
				obj.position = vector;
				if (Vector3.Distance(logicalPosition, OffsetDestination) < 0.5f)
				{
					this.DestinationReachedEvent?.Invoke();
					this.DestinationReachedEvent = null;
					isDestinationSet = false;
					if (destroyDelay > 0f)
					{
						canDestroyAfterTimestamp = Time.time + destroyDelay;
					}
					if (!dontSpawnEffectOnTarget && !string.IsNullOrEmpty(particlesOnHit))
					{
						dontSpawnEffectOnTarget = true;
						MonoSingleton<ParticleSystemPool>.Instance.PlayParticles(particlesOnHit, OffsetDestination);
					}
				}
			}
		}
	}
}
