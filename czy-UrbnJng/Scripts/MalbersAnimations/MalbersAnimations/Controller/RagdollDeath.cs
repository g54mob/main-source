using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.Controller
{
	public class RagdollDeath : State
	{
		[Header("Ragdoll")]
		[Tooltip("Ragdoll prefab that will replace the current animal controller")]
		public GameObject ragdollPrefab;

		public float Drag = 0.1f;

		public float AngularDrag = 0.1f;

		public bool EnablePreProcessing = true;

		public CollisionDetectionMode collision = CollisionDetectionMode.ContinuousSpeculative;

		[Tooltip("Destroy the Animal after the Ragdoll is created. If is set to false then it will only Hide the GameObject")]
		public bool DestroyAnimal = true;

		public override string StateName => "Death/Ragdoll Replace";

		public override string StateIDName => "Death";

		public override void Activate()
		{
			animal.Mode_Stop();
			animal.Mode_Interrupt();
			base.Activate();
			Replace();
		}

		public void Replace()
		{
			GameObject gameObject = Object.Instantiate(ragdollPrefab, base.transform.position, base.transform.rotation);
			CharacterJoint[] componentsInChildren = gameObject.GetComponentsInChildren<CharacterJoint>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].enablePreprocessing = true;
			}
			gameObject.SetActive(value: false);
			gameObject.transform.SetPositionAndRotation(base.transform.position, base.transform.rotation);
			Transform[] componentsInChildren2 = animal.RootBone.GetComponentsInChildren<Transform>();
			Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
			Transform[] array = componentsInChildren2;
			foreach (Transform transform in array)
			{
				dictionary[transform.name] = transform;
			}
			array = gameObject.GetComponentsInChildren<Transform>();
			foreach (Transform transform2 in array)
			{
				if (dictionary.TryGetValue(transform2.name, out var value))
				{
					transform2.SetPositionAndRotation(value.position, value.rotation);
				}
			}
			animal.Anim.enabled = false;
			SkinnedMeshRenderer[] componentsInChildren3 = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			MeshRenderer[] componentsInChildren4 = gameObject.GetComponentsInChildren<MeshRenderer>();
			SkinnedMeshRenderer[] array2 = componentsInChildren3;
			for (int i = 0; i < array2.Length; i++)
			{
				Object.Destroy(array2[i].gameObject);
			}
			MeshRenderer[] array3 = componentsInChildren4;
			for (int i = 0; i < array3.Length; i++)
			{
				Object.Destroy(array3[i].gameObject);
			}
			SkinnedMeshRenderer[] componentsInChildren5 = animal.GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: false);
			MeshRenderer[] componentsInChildren6 = animal.GetComponentsInChildren<MeshRenderer>(includeInactive: false);
			LODGroup[] componentsInChildren7 = animal.GetComponentsInChildren<LODGroup>();
			for (int i = 0; i < componentsInChildren7.Length; i++)
			{
				componentsInChildren7[i].transform.parent = gameObject.transform;
			}
			array2 = componentsInChildren5;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				if (skinnedMeshRenderer.gameObject.activeInHierarchy && skinnedMeshRenderer.GetComponentInParent<LODGroup>() == null)
				{
					skinnedMeshRenderer.transform.parent = gameObject.transform;
				}
				RemapSkinToNewBones(skinnedMeshRenderer, gameObject.transform);
			}
			array3 = componentsInChildren6;
			foreach (MeshRenderer meshRenderer in array3)
			{
				if (meshRenderer.gameObject.activeInHierarchy && meshRenderer.GetComponentInParent<LODGroup>() == null)
				{
					Transform parent = gameObject.transform.FindGrandChild(meshRenderer.transform.parent.name) ?? gameObject.transform.FindGrandChild(meshRenderer.transform.parent.parent.name);
					meshRenderer.transform.parent = parent;
				}
			}
			Vector3 force = Vector3.zero;
			Vector3 pos = Vector3.zero;
			Collider collider = null;
			ForceMode mode = ForceMode.VelocityChange;
			if (animal.TryGetComponent<IMDamage>(out var component))
			{
				force = component.HitDirection;
				pos = component.HitPosition;
				collider = component.HitCollider;
				mode = component.LastForceMode;
			}
			MDebug.Draw_Arrow(pos, force.normalized * 3f, Color.yellow, 5f);
			Rigidbody[] componentsInChildren8 = gameObject.GetComponentsInChildren<Rigidbody>();
			foreach (Rigidbody rigidbody in componentsInChildren8)
			{
				rigidbody.collisionDetectionMode = collision;
				rigidbody.isKinematic = false;
				rigidbody.velocity = animal.RB.velocity;
				rigidbody.drag = Drag;
				rigidbody.angularDrag = AngularDrag;
				if (collider != null && collider.name.Contains(rigidbody.name))
				{
					rigidbody.AddForce(force, mode);
				}
			}
			animal.OnStateChange.Invoke(ID);
			gameObject.SetActive(value: true);
			animal.Delay_Action(delegate
			{
				if (DestroyAnimal)
				{
					Object.Destroy(animal.gameObject);
				}
				else
				{
					animal.gameObject.SetActive(value: false);
				}
			});
		}

		private void RemapSkinToNewBones(SkinnedMeshRenderer thisRenderer, Transform RootBone)
		{
			if (thisRenderer == null)
			{
				return;
			}
			Transform rootBone = thisRenderer.rootBone;
			Transform[] componentsInChildren = RootBone.GetComponentsInChildren<Transform>();
			Dictionary<string, Transform> dictionary = new Dictionary<string, Transform>();
			Transform[] array = componentsInChildren;
			foreach (Transform transform in array)
			{
				dictionary[transform.name] = transform;
			}
			Transform[] bones = thisRenderer.bones;
			for (int j = 0; j < bones.Length; j++)
			{
				string text = bones[j].name;
				if (!dictionary.TryGetValue(text, out bones[j]))
				{
					Debug.LogError("failed to get bone: " + text);
				}
			}
			thisRenderer.bones = bones;
			if (dictionary.TryGetValue(rootBone.name, out var value))
			{
				thisRenderer.rootBone = value;
			}
		}
	}
}
