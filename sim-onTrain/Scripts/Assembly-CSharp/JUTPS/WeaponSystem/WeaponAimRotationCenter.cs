using System.Collections.Generic;
using UnityEngine;

namespace JUTPS.WeaponSystem
{
	[AddComponentMenu("JU TPS/Weapon System/Weapon Aim Rotation Center")]
	public class WeaponAimRotationCenter : MonoBehaviour
	{
		public int WeaponPositionsLengh;

		public List<string> WeaponPositionName = new List<string>();

		public List<Transform> WeaponPositionTransform = new List<Transform>();

		public List<int> ID = new List<int>();

		public List<Vector3> _storedLocalPositions = new List<Vector3>();

		public List<Quaternion> _storedLocalRotations = new List<Quaternion>();

		public void CreateWeaponPositionReference(string name)
		{
			WeaponPositionName.Add(name);
			Transform transform = JUGizmoDrawer.CreateRightHandGizmo().transform;
			transform.GetComponent<JUGizmoDrawer>().ModelToDraw = JUGizmoDrawer.DrawMesh.ArmedHand;
			transform.name = name;
			transform.SetParent(base.transform.GetChild(0));
			transform.localPosition = Vector3.zero;
			transform.localEulerAngles = new Vector3(0f, 11.383f, -94.913f);
			WeaponPositionTransform.Add(transform);
			Vector3 position = transform.position;
			_storedLocalPositions.Add(position);
			Quaternion rotation = transform.rotation;
			_storedLocalRotations.Add(rotation);
			WeaponPositionsLengh++;
			ID.Add(WeaponPositionsLengh);
			StoreLocalTransform();
			UpdateSwitchID();
		}

		public void RemoveWeaponPositionReference(int index)
		{
			WeaponPositionName.RemoveAt(index);
			if (WeaponPositionTransform[index].gameObject != null)
			{
				Object.DestroyImmediate(WeaponPositionTransform[index].gameObject);
			}
			WeaponPositionTransform.RemoveAt(index);
			ID.RemoveAt(index);
			WeaponPositionsLengh = WeaponPositionName.Count - 1;
			_storedLocalPositions.RemoveAt(index);
			_storedLocalRotations.RemoveAt(index);
			StoreLocalTransform();
			UpdateSwitchID();
		}

		public void StoreLocalTransform()
		{
			_storedLocalPositions = new List<Vector3>();
			_storedLocalRotations = new List<Quaternion>();
			foreach (Transform item in WeaponPositionTransform)
			{
				if (item != null)
				{
					_storedLocalPositions.Add(item.localPosition);
					_storedLocalRotations.Add(item.localRotation);
				}
			}
		}

		public void UpdateSwitchID()
		{
			for (int i = 0; i < WeaponPositionName.Count; i++)
			{
				ID[i] = i;
				WeaponPositionTransform[i].name = WeaponPositionName[i];
			}
		}

		private void Start()
		{
			StoreLocalTransform();
		}
	}
}
