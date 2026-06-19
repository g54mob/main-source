using System.Collections.Generic;
using Aggro.Core;
using Unity.Mathematics;
using UnityEngine;

public class PlayerLiftVisual : EntityBehaviourBase
{
	public float raiseHeight = 1f;

	[Min(0f)]
	public float raiseLowerDuration = 0.2f;

	public EasingFunction.Ease raiseLoserEase = EasingFunction.Ease.EaseOutQuint;

	public Transform target;

	private float _time;

	private bool _prevIsRaised;

	private Vector3 _origPosition;

	private static List<Entity> _entities = new List<Entity>();

	private VehicleController _vehicleController;

	private NitroController _nitroController;

	public float velOffset = 1f;

	public float stackPower = 1.1f;

	public float velRotOffset = 1f;

	private Vector3 _stackBend = Vector3.zero;

	public float stackBendLerpSpeed = 1f;

	protected override void OnInitializeBehaviour()
	{
		_origPosition = target.localPosition;
	}

	protected override void OnEntityCreated()
	{
		_vehicleController = base.entity.GetObject<VehicleController>();
		_nitroController = base.entity.GetObject<NitroController>();
	}

	protected override void OnUpdatePresentationLate()
	{
		PlayerGrabber playerGrabber = base.entity.GetObject<PlayerGrabber>();
		bool syncLiftRaised = playerGrabber.syncLiftRaised;
		if (syncLiftRaised != _prevIsRaised)
		{
			_prevIsRaised = syncLiftRaised;
			_time = 0f;
		}
		else
		{
			_time += Time.deltaTime;
		}
		float num = EasingFunction.Evaluate(raiseLoserEase, 0f, raiseHeight, math.saturate(_time / raiseLowerDuration));
		Vector3 position = target.parent.TransformPoint(_origPosition);
		position += Vector3.up * num;
		target.position = position;
		if (!playerGrabber.syncGrabTarget.Exists())
		{
			return;
		}
		Grabbable grabbable = playerGrabber.syncGrabTarget.GetObject<Grabbable>();
		if (base.isServer && playerGrabber.serverGrabbed != playerGrabber.syncGrabTarget)
		{
			return;
		}
		Vector3 position2 = playerGrabber.grabbedContainer.transform.position;
		_entities.Clear();
		grabbable.GetStack(_entities);
		for (int i = 0; i < _entities.Count; i++)
		{
			Entity entity = _entities[i];
			if (entity.Exists())
			{
				Vector3 vector = _vehicleController.velocitySync / _vehicleController.maxSpeedForward * 0.8f;
				vector = Vector3.ClampMagnitude(vector, 1f);
				_stackBend = Vector3.Lerp(_stackBend, vector, stackBendLerpSpeed * Time.deltaTime);
				Vector3 position3 = position2 + target.transform.up * i - Vector3.Project(_stackBend, target.forward) * velOffset * Mathf.Pow(i, stackPower);
				Transform transform = entity.transform;
				if (i > 0)
				{
					Vector3 vector2 = _vehicleController.transform.InverseTransformVector(Vector3.Project(_stackBend, target.forward));
					transform.localRotation = Quaternion.Euler(new Vector3(0f - vector2.z, vector2.y, 0f - vector2.x) * velRotOffset * Mathf.Pow(i, stackPower));
				}
				else
				{
					transform.localRotation = Quaternion.identity;
				}
				transform.position = position3;
			}
		}
	}
}
