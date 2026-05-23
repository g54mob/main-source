using System.Collections;
using UnityEngine;

public abstract class IUIAnimationSequence : MonoBehaviour
{
	public abstract void Reset();

	public abstract IEnumerator PlayAnimation(UIFrame contextFrame);
}
