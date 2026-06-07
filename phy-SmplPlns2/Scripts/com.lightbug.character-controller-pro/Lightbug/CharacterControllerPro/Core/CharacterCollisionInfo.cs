using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Core
{
	public struct CharacterCollisionInfo
	{
		public Vector3 groundContactPoint;

		public Vector3 groundContactNormal;

		public Vector3 groundStableNormal;

		public float groundSlopeAngle;

		public bool headCollision;

		public Contact headContact;

		public float headAngle;

		public bool wallCollision;

		public Contact wallContact;

		public float wallAngle;

		public bool isOnEdge;

		public float edgeAngle;

		public GameObject groundObject;

		public int groundLayer;

		public Collider groundCollider3D;

		public Collider2D groundCollider2D;

		public Rigidbody groundRigidbody3D;

		public Rigidbody2D groundRigidbody2D;

		public void Reset()
		{
			ResetGroundInfo();
			ResetWallInfo();
			ResetHeadInfo();
		}

		public void ResetWallInfo()
		{
			wallCollision = false;
			wallContact = default(Contact);
			wallAngle = 0f;
		}

		public void SetWallInfo(in Contact contact, CharacterActor characterActor)
		{
			wallCollision = true;
			wallAngle = Vector3.Angle(characterActor.Up, contact.normal);
			wallContact = contact;
		}

		public void ResetHeadInfo()
		{
			headCollision = false;
			headContact = default(Contact);
			headAngle = 0f;
		}

		public void SetHeadInfo(in Contact contact, CharacterActor characterActor)
		{
			headCollision = true;
			headAngle = Vector3.Angle(characterActor.Up, headContact.normal);
			headContact = contact;
		}

		public void SetGroundInfo(in CollisionInfo collisionInfo, CharacterActor characterActor)
		{
			if (collisionInfo.hitInfo.hit)
			{
				isOnEdge = collisionInfo.isAnEdge;
				edgeAngle = collisionInfo.edgeAngle;
				groundContactNormal = ((collisionInfo.contactSlopeAngle < 90f) ? collisionInfo.hitInfo.normal : characterActor.Up);
				groundContactPoint = collisionInfo.hitInfo.point;
				groundStableNormal = characterActor.GetGroundSlopeNormal(collisionInfo);
				groundSlopeAngle = Vector3.Angle(characterActor.Up, groundStableNormal);
				groundObject = collisionInfo.hitInfo.transform.gameObject;
				groundLayer = groundObject.layer;
				groundCollider2D = collisionInfo.hitInfo.collider2D;
				groundCollider3D = collisionInfo.hitInfo.collider3D;
				groundRigidbody2D = collisionInfo.hitInfo.rigidbody2D;
				groundRigidbody3D = collisionInfo.hitInfo.rigidbody3D;
				Vector3 vector = Vector3.zero;
				if (collisionInfo.hitInfo.rigidbody2D != null)
				{
					vector = collisionInfo.hitInfo.rigidbody2D.GetPointVelocity(groundContactPoint);
				}
				else if (collisionInfo.hitInfo.rigidbody3D != null)
				{
					vector = collisionInfo.hitInfo.rigidbody3D.GetPointVelocity(groundContactPoint);
				}
				Vector3 relativeVelocity = characterActor.Velocity - vector;
				Contact item = new Contact(groundContactPoint, groundContactNormal, vector, relativeVelocity);
				characterActor.GroundContacts.Add(item);
			}
			else
			{
				ResetGroundInfo();
			}
		}

		private void SetGroundContact(in CollisionInfo collisionInfo, CharacterActor characterActor)
		{
			if (collisionInfo.hitInfo.hit)
			{
				Vector3 point = collisionInfo.hitInfo.point;
				Vector3 normal = collisionInfo.hitInfo.normal;
				Vector3 vector = Vector3.zero;
				if (collisionInfo.hitInfo.rigidbody2D != null)
				{
					vector = collisionInfo.hitInfo.rigidbody2D.GetPointVelocity(point);
				}
				else if (collisionInfo.hitInfo.rigidbody3D != null)
				{
					vector = collisionInfo.hitInfo.rigidbody3D.GetPointVelocity(point);
				}
				Vector3 relativeVelocity = characterActor.Velocity - vector;
				Contact item = new Contact(point, normal, vector, relativeVelocity);
				characterActor.GroundContacts.Add(item);
			}
		}

		public void ResetGroundInfo()
		{
			groundContactPoint = Vector3.zero;
			groundContactNormal = Vector3.up;
			groundStableNormal = Vector3.up;
			groundSlopeAngle = 0f;
			isOnEdge = false;
			edgeAngle = 0f;
			groundObject = null;
			groundLayer = 0;
			groundCollider3D = null;
			groundCollider2D = null;
		}
	}
}
