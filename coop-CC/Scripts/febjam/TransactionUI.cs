using Aggro.Core;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class TransactionUI : EntityBehaviourBase
{
	public float delaySec = 1f;

	public int amount = 9999;

	public TextMeshProUGUI text;

	public Color spendColor = Color.white;

	public Color earnColor = Color.white;

	public Transform followTransform;

	private float _startTime;

	public float destroyAfterSeconds = 5f;

	public bool destroySelf;

	protected override void OnEntityCreated()
	{
		_startTime = Time.time;
	}

	protected override void OnUpdateSimulation()
	{
		if (Time.time - _startTime > destroyAfterSeconds && destroySelf)
		{
			base.entity.GetStruct<PoolableEntityReference>().Release();
		}
	}

	protected override void OnUpdatePresentationLate()
	{
		if (followTransform != null)
		{
			base.transform.localPosition = SetTargetPosition(followTransform.position);
		}
		string text = ((amount > 0) ? "+" : "-");
		this.text.text = text + "$" + Mathf.Abs(amount);
		Color color = ((amount > 0) ? earnColor : spendColor);
		this.text.color = new Color(color.r, color.g, color.b, this.text.color.a);
		_ = Camera.main;
	}

	private Vector2 SetTargetPosition(Vector3 worldPos)
	{
		Vector3 vector = GameUtil.mainCamera.WorldToScreenPoint(worldPos);
		vector *= math.sign(vector.z) / Options.renderScale;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.transform.parent.GetComponent<RectTransform>(), vector, GameUtil.uiCamera, out var localPoint);
		return localPoint;
	}
}
