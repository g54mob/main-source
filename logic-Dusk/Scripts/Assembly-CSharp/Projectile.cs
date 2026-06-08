using System;
using UnityEngine;

public class Projectile : MonoBehaviour, IUpdateCameraView
{
	private int _id = -1;

	private ProjectileStateEnum _state;

	private float _damagePayload;

	private DamageType _damageType;

	private float _velocityScale = 0.1f;

	private float _speed;

	private ICombatTarget _sourceObject;

	private ICombatTarget _destinationObject;

	private int _accuracy = 100;

	private bool _instantDamage;

	private GameObject _plane1;

	private GameObject _plane2;

	private GameObject _plane3;

	private GameObject _plane4;

	public ProjectileStateEnum State
	{
		get
		{
			return _state;
		}
	}

	private void OnDestroy()
	{
		_plane1 = null;
		_plane2 = null;
		_plane3 = null;
		_plane4 = null;
	}

	private void Update()
	{
		if (GlobalSettings.IsGamePaused || _state != ProjectileStateEnum.InFlight)
		{
			return;
		}
		if (_destinationObject != null)
		{
			MonoBehaviour monoBehaviour = _destinationObject as MonoBehaviour;
			if (monoBehaviour != null && monoBehaviour.gameObject == null)
			{
				Debug.LogWarning("Projectile's target gameObject went null, sourced from " + _sourceObject);
				_state = ProjectileStateEnum.None;
				HideProjectile();
				base.gameObject.SetActive(false);
				return;
			}
			Vector3 vector = Vector3.zero;
			try
			{
				vector = _destinationObject.Position;
			}
			catch (Exception)
			{
				int num = 0;
				num++;
			}
			if (vector == Vector3.zero)
			{
				Debug.LogWarning("Projectile's target transform went null, sourced from " + _sourceObject);
				_state = ProjectileStateEnum.None;
				HideProjectile();
				base.gameObject.SetActive(false);
				return;
			}
			base.transform.LookAt(vector);
			float num2 = Vector3.Distance(_destinationObject.Position, base.transform.position);
			if (num2 > 0.5f)
			{
				moveForward();
				return;
			}
			if (_accuracy != 0 && UnityEngine.Random.Range(1, 101) <= 100 - _accuracy)
			{
				_sourceObject.MissedTarget(_destinationObject, _damagePayload);
				HideProjectile();
				_state = ProjectileStateEnum.Discard;
				return;
			}
			if (!_instantDamage)
			{
				_destinationObject.TakeDamage(_damagePayload, _damageType, _sourceObject);
			}
			HideProjectile();
			_state = ProjectileStateEnum.Sploded;
		}
		else
		{
			Debug.LogWarning("Projectile's target went null, sourced from " + _sourceObject);
			_state = ProjectileStateEnum.None;
			HideProjectile();
			base.gameObject.SetActive(false);
		}
	}

	private void HideProjectile()
	{
		GetComponent<Renderer>().enabled = false;
		if (_plane1 != null)
		{
			_plane1.GetComponent<Renderer>().enabled = false;
		}
		if (_plane2 != null)
		{
			_plane2.GetComponent<Renderer>().enabled = false;
		}
		if (_plane3 != null)
		{
			_plane3.GetComponent<Renderer>().enabled = false;
		}
		if (_plane4 != null)
		{
			_plane4.GetComponent<Renderer>().enabled = false;
		}
	}

	private Vector3 GetVelocityDelta()
	{
		return base.transform.forward * _velocityScale * _speed * 60f * Time.deltaTime;
	}

	private void moveForward()
	{
		base.transform.position += GetVelocityDelta();
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, -0.15f);
	}

	public void SetId(int id)
	{
		if (_id == -1)
		{
			_id = id;
		}
	}

	public void StartProjectile(ICombatTarget source, ICombatTarget destination, float speed, float damage, DamageType type, int accuracy, bool instantDamage)
	{
		if (base.transform.FindChild("Plane1") != null)
		{
			_plane1 = base.transform.FindChild("Plane1").gameObject;
			_plane2 = base.transform.FindChild("Plane2").gameObject;
			_plane3 = base.transform.FindChild("Plane3").gameObject;
			_plane4 = base.transform.FindChild("Plane4").gameObject;
		}
		_sourceObject = source;
		_destinationObject = destination;
		_speed = speed;
		_damagePayload = damage;
		_damageType = type;
		_accuracy = accuracy;
		_instantDamage = instantDamage;
		if (_accuracy == 100)
		{
			_accuracy = 0;
		}
		base.transform.position = source.Position;
		_state = ProjectileStateEnum.InFlight;
		if (_instantDamage)
		{
			_destinationObject.TakeDamage(_damagePayload, _damageType, _sourceObject);
		}
		UpdateCameraView();
	}

	public void UpdateCameraView()
	{
		if (GlobalSettings.cameraMode == CameraMode.Schematic)
		{
			if (GlobalSettings.OverrideCameraVisibility)
			{
				GetComponent<Renderer>().enabled = true;
				return;
			}
			GetComponent<Renderer>().enabled = false;
			if (_plane1 != null)
			{
				_plane1.GetComponent<Renderer>().enabled = false;
				_plane2.GetComponent<Renderer>().enabled = false;
				_plane3.GetComponent<Renderer>().enabled = false;
				_plane4.GetComponent<Renderer>().enabled = false;
			}
		}
		else
		{
			GetComponent<Renderer>().enabled = true;
			if (_plane1 != null)
			{
				_plane1.GetComponent<Renderer>().enabled = true;
				_plane2.GetComponent<Renderer>().enabled = true;
				_plane3.GetComponent<Renderer>().enabled = true;
				_plane4.GetComponent<Renderer>().enabled = true;
			}
		}
	}
}
