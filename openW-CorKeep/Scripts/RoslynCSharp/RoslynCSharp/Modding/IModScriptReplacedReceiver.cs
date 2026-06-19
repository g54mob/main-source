using UnityEngine;

namespace RoslynCSharp.Modding
{
	public interface IModScriptReplacedReceiver
	{
		void OnWillReplaceScript(MonoBehaviour replacementBehaviour);
	}
}
