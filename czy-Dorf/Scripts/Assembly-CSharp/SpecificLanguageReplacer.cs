using UnityEngine;

public abstract class SpecificLanguageReplacer : MonoBehaviour
{
	public abstract Language Language { get; }

	public abstract string ApplySpecificNumberingGrammar(string inputString, int number);
}
