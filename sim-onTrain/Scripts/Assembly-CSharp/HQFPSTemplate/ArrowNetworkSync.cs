using System.Collections;
using Mirror;
using Mirror.RemoteCalls;
using UnityEngine;

namespace HQFPSTemplate
{
	[RequireComponent(typeof(ShaftedProjectile))]
	public class ArrowNetworkSync : NetworkBehaviour
	{
		private ShaftedProjectile projectile;

		private Rigidbody rb;

		private bool isStopped;

		public bool IsStopped => isStopped;

		private void Awake()
		{
			projectile = GetComponent<ShaftedProjectile>();
			rb = GetComponent<Rigidbody>();
			if (rb != null)
			{
				rb.isKinematic = true;
			}
		}

		public void InitializeArrow(Entity launcher)
		{
			if (launcher != null)
			{
				projectile.NetworkLaunch(launcher);
			}
		}

		[ClientRpc]
		public void RpcLaunchArrow(Vector3 spawnPos, Vector3 direction, float speed, float gravityMult, double serverTime)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(spawnPos);
			writer.WriteVector3(direction);
			writer.WriteFloat(speed);
			writer.WriteFloat(gravityMult);
			writer.WriteDouble(serverTime);
			SendRPCInternal("System.Void HQFPSTemplate.ArrowNetworkSync::RpcLaunchArrow(UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single,System.Double)", 1993955592, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		[ClientRpc]
		public void RpcStopArrow(Vector3 impactPoint, Vector3 impactForward)
		{
			NetworkWriterPooled writer = NetworkWriterPool.Get();
			writer.WriteVector3(impactPoint);
			writer.WriteVector3(impactForward);
			SendRPCInternal("System.Void HQFPSTemplate.ArrowNetworkSync::RpcStopArrow(UnityEngine.Vector3,UnityEngine.Vector3)", 613064913, writer, 0, includeOwner: true);
			NetworkWriterPool.Return(writer);
		}

		public void ServerStopArrow(Vector3 impactPoint, GameObject hitObject)
		{
			if (base.isServer)
			{
				isStopped = true;
				base.transform.position = impactPoint;
				if (rb != null)
				{
					rb.velocity = Vector3.zero;
					rb.angularVelocity = Vector3.zero;
					rb.isKinematic = true;
				}
				if (hitObject != null)
				{
					base.transform.SetParent(hitObject.transform);
				}
				RpcStopArrow(impactPoint, base.transform.forward);
			}
		}

		private IEnumerator SmoothSnapToImpact(Vector3 targetPos, Vector3 targetForward, float duration)
		{
			Vector3 startPos = base.transform.position;
			Quaternion startRot = base.transform.rotation;
			Quaternion targetRot = Quaternion.LookRotation(targetForward);
			float elapsed = 0f;
			while (elapsed < duration)
			{
				elapsed += Time.deltaTime;
				float t = Mathf.Clamp01(elapsed / duration);
				base.transform.position = Vector3.Lerp(startPos, targetPos, t);
				base.transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
				yield return null;
			}
			base.transform.position = targetPos;
			base.transform.rotation = targetRot;
			ParentToHitObject(targetPos, targetForward);
			projectile.OnNetworkImpact();
		}

		private void ParentToHitObject(Vector3 impactPoint, Vector3 forward)
		{
			if (Physics.Raycast(impactPoint - forward * 0.5f, forward, out var hitInfo, 1f))
			{
				base.transform.SetParent(hitInfo.transform);
			}
		}

		public override bool Weaved()
		{
			return true;
		}

		protected void UserCode_RpcLaunchArrow__Vector3__Vector3__Single__Single__Double(Vector3 spawnPos, Vector3 direction, float speed, float gravityMult, double serverTime)
		{
			if (!base.isServer)
			{
				double num = NetworkTime.time - serverTime;
				if (num < 0.0)
				{
					num = 0.0;
				}
				float num2 = (float)num;
				Vector3 vector = direction * speed;
				Vector3 vector2 = Physics.gravity * gravityMult;
				Vector3 position = spawnPos + vector * num2 + 0.5f * vector2 * num2 * num2;
				Vector3 vector3 = vector + vector2 * num2;
				if (rb != null)
				{
					rb.isKinematic = false;
					base.transform.position = position;
					rb.velocity = vector3;
				}
				if (vector3.sqrMagnitude > 0.1f)
				{
					base.transform.rotation = Quaternion.LookRotation(vector3);
				}
				projectile.NetworkLaunch(null);
			}
		}

		protected static void InvokeUserCode_RpcLaunchArrow__Vector3__Vector3__Single__Single__Double(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcLaunchArrow called on server.");
			}
			else
			{
				((ArrowNetworkSync)obj).UserCode_RpcLaunchArrow__Vector3__Vector3__Single__Single__Double(reader.ReadVector3(), reader.ReadVector3(), reader.ReadFloat(), reader.ReadFloat(), reader.ReadDouble());
			}
		}

		protected void UserCode_RpcStopArrow__Vector3__Vector3(Vector3 impactPoint, Vector3 impactForward)
		{
			if (!isStopped)
			{
				isStopped = true;
				if (rb != null)
				{
					rb.velocity = Vector3.zero;
					rb.angularVelocity = Vector3.zero;
					rb.isKinematic = true;
				}
				if (Vector3.Distance(base.transform.position, impactPoint) < 1.5f)
				{
					base.transform.position = impactPoint;
					base.transform.rotation = Quaternion.LookRotation(impactForward);
					ParentToHitObject(impactPoint, impactForward);
					projectile.OnNetworkImpact();
				}
				else
				{
					StartCoroutine(SmoothSnapToImpact(impactPoint, impactForward, 0.1f));
				}
			}
		}

		protected static void InvokeUserCode_RpcStopArrow__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
			if (!NetworkClient.active)
			{
				Debug.LogError("RPC RpcStopArrow called on server.");
			}
			else
			{
				((ArrowNetworkSync)obj).UserCode_RpcStopArrow__Vector3__Vector3(reader.ReadVector3(), reader.ReadVector3());
			}
		}

		static ArrowNetworkSync()
		{
			RemoteProcedureCalls.RegisterRpc(typeof(ArrowNetworkSync), "System.Void HQFPSTemplate.ArrowNetworkSync::RpcLaunchArrow(UnityEngine.Vector3,UnityEngine.Vector3,System.Single,System.Single,System.Double)", InvokeUserCode_RpcLaunchArrow__Vector3__Vector3__Single__Single__Double);
			RemoteProcedureCalls.RegisterRpc(typeof(ArrowNetworkSync), "System.Void HQFPSTemplate.ArrowNetworkSync::RpcStopArrow(UnityEngine.Vector3,UnityEngine.Vector3)", InvokeUserCode_RpcStopArrow__Vector3__Vector3);
		}
	}
}
