using System.Threading;
using Cysharp.Text;
using Cysharp.Threading.Tasks;
using LitMotion;
using TMPro;
using UnityEngine;

public class ValueNumericDisplay : MonoBehaviour
{
	[SerializeField]
	protected TMP_Text field;

	[SerializeField]
	private bool dimLeadingZeros;

	[SerializeField]
	[Range(0f, 1f)]
	private float leadingZeroAlpha = 0.5f;

	protected double? Number;

	private MotionHandle _handle;

	public void Direct(double number, NumericFormat format)
	{
		Animate(number, format, 0f);
	}

	public void Direct(double number, string format)
	{
		Animate(number, format, 0f);
	}

	public void Animate(double number, NumericFormat format, float duration)
	{
		Animate(number, format.Value(), duration);
	}

	public virtual void Animate(double number, string format, float duration)
	{
		Play(number, format, duration);
	}

	public UniTask AnimateAsync(double number, NumericFormat format, float duration, CancellationToken token)
	{
		return AnimateAsync(number, format.Value(), duration, token);
	}

	public async UniTask AnimateAsync(double number, string format, float duration, CancellationToken token)
	{
		if (duration == 0f)
		{
			Play(number, format, 0f);
			return;
		}
		Play(number, format, duration);
		await _handle.ToUniTask(token);
	}

	private void Play(double number, string format, float duration)
	{
		if (_handle.IsValid())
		{
			_handle.TryCancel();
		}
		if (!Number.HasValue || duration == 0f)
		{
			Number = number;
			field.SetTextFormat(format, number);
			if (dimLeadingZeros)
			{
				LeadingZerosDimmer.ApplyDim(field, leadingZeroAlpha);
			}
		}
		else
		{
			_handle = (dimLeadingZeros ? LMotion.Create(Number.Value, number, duration).BindToTextDimLeadingZeros(field, format, leadingZeroAlpha).AddTo(this) : LMotion.Create(Number.Value, number, duration).BindToText(field, format).AddTo(this));
			Number = number;
		}
	}
}
