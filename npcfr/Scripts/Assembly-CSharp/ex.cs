using System.Collections.Generic;
using Player.GameplayInput.ButtonsActions;
using UnityEngine;
using Views.Hints;

public abstract class ex : MonoBehaviour
{
	public abstract IEnumerable<ButtonActionData> duh(HintBarViewController a);
}
