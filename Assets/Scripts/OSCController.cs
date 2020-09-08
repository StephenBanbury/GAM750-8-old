using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;

namespace Assets.Scripts
{
	public class OSCController : MonoBehaviour
	{
		public OscOut oscOut;

		public Text outputHeaderLabel;

        StringBuilder _sb;

        const string _videoSelectAddress = "/select/video";
        const string _streamSelectAddress = "/select/stream";
        const string _displaySelectAddress = "/select/display";


		void Awake()
		{
			_sb = new StringBuilder();
		}


		void Start()
		{
			_sb.Clear();
			_sb.Append( "PORT: " ); _sb.Append( oscOut.port );
			_sb.Append( ", ADDRESS: " ); _sb.Append( oscOut.remoteIpAddress );

			outputHeaderLabel.text = _sb.ToString();
		}
		
		// The following methods are meant to be linked to Unity's runtime UI from the Unity Editor.

        public void VideoSelect(int videoId)
        {
			Debug.Log($"VideoId: {videoId}");
            oscOut.Send(_videoSelectAddress, videoId);
		}
        public void StreamSelect(int streamId)
        {
            Debug.Log($"StreamId: {streamId}");
            oscOut.Send(_streamSelectAddress, streamId);
        }

		public void DisplaySelect(int displayId)
        {
			Debug.Log($"DisplayId: {displayId}");
            oscOut.Send(_displaySelectAddress, displayId);
		}

	}
}