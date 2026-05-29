using System;
using System.Runtime.Serialization;
using JetBrains.Annotations;

namespace Eflatun.SceneReference.Exceptions
{
	[Serializable]
	[PublicAPI]
	public class EmptySceneReferenceException : SceneReferenceException
	{
		private const string ExceptionMessage = "The SceneReference is empty (not assigned anything). To fix this, make sure the 'SceneReference' is assigned a valid scene asset.";

		internal EmptySceneReferenceException()
			: base("The SceneReference is empty (not assigned anything). To fix this, make sure the 'SceneReference' is assigned a valid scene asset.")
		{
		}

		internal EmptySceneReferenceException(Exception inner)
			: base("The SceneReference is empty (not assigned anything). To fix this, make sure the 'SceneReference' is assigned a valid scene asset.", inner)
		{
		}

		private protected EmptySceneReferenceException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
