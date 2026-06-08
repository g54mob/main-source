using System.Threading.Tasks;
using Rhizomatic.Reactive;
using UnityEngine;

namespace Rhizomatic
{
	public abstract class PageTransition : MonoBehaviour
	{
		public abstract Task Open(View view);

		public abstract Task Close(View view);
	}
}
