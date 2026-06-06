using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations.IK
{
	[CreateAssetMenu(menuName = "Malbers Animations/IK/IK Proccessor Profile")]
	public class IKProccesorProfile : ScriptableObject
	{
		[SerializeReference]
		[NonReorderable]
		public List<IKProcessor> IKProcesors;
	}
}
