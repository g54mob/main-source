using System.Collections.Generic;
using UnityEngine;

public abstract class TooltipUI : MonoBehaviour
{
	public abstract void Setup(Dictionary<string, object> data);
}
