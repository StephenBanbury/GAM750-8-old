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
        public Text oscAddressLabel;

        StringBuilder _sb;

        const string _videoSelectAddress = "/select/video";
        const string _streamSelectAddress = "/select/stream";
        const string _displaySelectAddress = "/select/display";
        const string _formationSelectAddress = "/select/formation";


		void Awake()
		{
			_sb = new StringBuilder();
		}


		void Start()
		{
			_sb.Clear();
			_sb.Append( "PORT: " ); _sb.Append( oscOut.port );
			_sb.Append( ", IP ADDRESS: " ); _sb.Append( oscOut.remoteIpAddress );

			outputHeaderLabel.text = _sb.ToString();
            oscAddressLabel.text = "";
        }
		
		// The following methods are meant to be linked to Unity's runtime UI from the Unity Editor.

        public void VideoSelect(int videoId)
        {
			Debug.Log($"VideoId: {videoId}");
            oscAddressLabel.text = $"{_videoSelectAddress}/{videoId}";
            oscOut.Send(_videoSelectAddress, videoId);
		}
        public void StreamSelect(int streamId)
        {
            Debug.Log($"StreamId: {streamId}");
            oscAddressLabel.text = $"{_streamSelectAddress}/{streamId}";
            oscOut.Send(_streamSelectAddress, streamId);
        }

		public void DisplaySelect(int displayId)
        {
			Debug.Log($"DisplayId: {displayId}");
            oscAddressLabel.text = $"{_displaySelectAddress}/{displayId}";
            oscOut.Send(_displaySelectAddress, displayId);
		}

        public void FormationSelect(int formationId)
        {
            Debug.Log($"FormationId: {formationId}");
            oscAddressLabel.text = $"{_formationSelectAddress}/{formationId}";
            oscOut.Send(_formationSelectAddress, formationId);
        }

	}
}