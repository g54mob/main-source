using System.Collections;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using Mirror.RemoteCalls;
using Unity.Mathematics;
using UnityEngine;

public class BoxForm : NetworkEntityBehaviourBase, IBoxActivated
{
	public enum ChangeStrategy
	{
		Ordered = 0,
		OrderedLoop = 1,
		Random = 2
	}

	private static readonly int ChangeForm;

	public ChangeStrategy strategy;

	public bool canOnlyBeShippedInCorrectForm;

	public bool onceInCorrectFormStayInCorrectForm = true;

	public int correctFormIndex;

	public string correctFormAchievement;

	public string correctFormMeteorAchievement;

	public int startIndex;

	public GameObject[] forms;

	private int _serverCurrentFormIndex;

	[Header("Visual")]
	public GameObject visualParent;

	public float scaleEffectTimeSeconds = 0.5f;

	public EasingFunction.Ease scaleEffectEaseIn = EasingFunction.Ease.Linear;

	public EasingFunction.Ease scaleEffectEaseOut = EasingFunction.Ease.Linear;

	public float scaleEffectStrength = 0.5f;

	public GameObject changeFormVFX;

	public bool parentVfxToTransform;

	public Animator animator;

	protected override void OnEntityCreated()
	{
		for (int i = 0; i < forms.Length; i++)
		{
			forms[i].SetActive(i == startIndex);
		}
		if (base.isServer)
		{
			_serverCurrentFormIndex = startIndex;
		}
	}

	[ClientRpc]
	private void RpcFormChanged(int newIndex)
	{
		NetworkWriterPooled writer = NetworkWriterPool.Get();
		writer.WriteVarInt(newIndex);
		SendRPCInternal("System.Void BoxForm::RpcFormChanged(System.Int32)", -1082336570, writer, 0, includeOwner: true);
		NetworkWriterPool.Return(writer);
	}

	[Server]
	public bool ServerCanBeShipped()
	{
		if (!NetworkServer.active)
		{
			Debug.LogWarning("[Server] function 'System.Boolean BoxForm::ServerCanBeShipped()' called when server was not active");
			return default(bool);
		}
		if (canOnlyBeShippedInCorrectForm)
		{
			return _serverCurrentFormIndex == correctFormIndex;
		}
		return true;
	}

	private IEnumerator FormChangeScaleCo()
	{
		float time = 0f;
		while (time < scaleEffectTimeSeconds)
		{
			float num = time / scaleEffectTimeSeconds;
			time += Time.deltaTime;
			float num2 = ((!(num <= 0.5f)) ? EasingFunction.Evaluate(scaleEffectEaseOut, 1f - (num - 0.5f) * 2f) : EasingFunction.Evaluate(scaleEffectEaseIn, num * 2f));
			visualParent.transform.localScale = Vector3.one + Vector3.one * num2 * scaleEffectStrength;
			yield return null;
		}
	}

	public void ServerBoxActivated(ActivationContext context)
	{
		if (onceInCorrectFormStayInCorrectForm && canOnlyBeShippedInCorrectForm && _serverCurrentFormIndex == correctFormIndex)
		{
			return;
		}
		int num2;
		switch (strategy)
		{
		case ChangeStrategy.Ordered:
			num2 = math.min(_serverCurrentFormIndex + 1, forms.Length - 1);
			break;
		case ChangeStrategy.OrderedLoop:
			num2 = (_serverCurrentFormIndex + 1) % forms.Length;
			break;
		case ChangeStrategy.Random:
		{
			Unity.Mathematics.Random random = MathUtil.GetRandom(base.entity.GetSeed(), TimeUtil.frame);
			int num = 0;
			num2 = -1;
			do
			{
				num++;
				if (num >= 100)
				{
					Debug.LogWarning("Hit max iterations while trying to change forms!");
					break;
				}
				num2 = random.NextInt(0, forms.Length);
			}
			while (num2 == _serverCurrentFormIndex);
			break;
		}
		default:
			throw new InvalidEnumException();
		}
		_serverCurrentFormIndex = num2;
		if (canOnlyBeShippedInCorrectForm && _serverCurrentFormIndex == correctFormIndex)
		{
			if (context.type == ActivationContextType.Kicked && !string.IsNullOrEmpty(correctFormAchievement) && context.connection != null && context.connection.isReady)
			{
				NetworkAggroManagerBase<AchievementManager>.instance.ServerUnlockAchievement(context.connection, correctFormAchievement);
			}
			if (context.type == ActivationContextType.Explosion && context.subType == ActivationContextSubType.Meteor && !string.IsNullOrEmpty(correctFormMeteorAchievement))
			{
				NetworkAggroManagerBase<AchievementManager>.instance.ServerUnlockAchievement(correctFormMeteorAchievement);
			}
		}
		RpcFormChanged(_serverCurrentFormIndex);
	}

	static BoxForm()
	{
		ChangeForm = Animator.StringToHash("changeForm");
		RemoteProcedureCalls.RegisterRpc(typeof(BoxForm), "System.Void BoxForm::RpcFormChanged(System.Int32)", InvokeUserCode_RpcFormChanged__Int32);
	}

	public override bool Weaved()
	{
		return true;
	}

	protected void UserCode_RpcFormChanged__Int32(int newIndex)
	{
		StopAllCoroutines();
		StartCoroutine(FormChangeScaleCo());
		if (changeFormVFX != null)
		{
			if (parentVfxToTransform)
			{
				Object.Instantiate(changeFormVFX, base.transform.position, Quaternion.identity, base.transform);
			}
			else
			{
				Object.Instantiate(changeFormVFX, base.transform.position, Quaternion.identity);
			}
		}
		for (int i = 0; i < forms.Length; i++)
		{
			forms[i].SetActive(newIndex == i);
		}
		if (animator != null)
		{
			animator.SetTrigger(ChangeForm);
		}
	}

	protected static void InvokeUserCode_RpcFormChanged__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		if (!NetworkClient.active)
		{
			Debug.LogError("RPC RpcFormChanged called on server.");
		}
		else
		{
			((BoxForm)obj).UserCode_RpcFormChanged__Int32(reader.ReadVarInt());
		}
	}
}
