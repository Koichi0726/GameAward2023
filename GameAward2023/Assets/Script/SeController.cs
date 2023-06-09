using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeController : MonoBehaviour
{
	[SerializeReference] AudioSource m_audioSource;
	[SerializeReference] List<AudioClip> m_seClips;

	public void PlaySe(string clipName)
	{
		//--- 同一の名前を探索
		foreach(AudioClip clip in m_seClips)
		{
			// 一致しない物はスルー
			if (clipName != clip.name) continue;

			//--- 一致したSEを再生
			m_audioSource.clip = clip;
			m_audioSource.Play();
			return;
		}
	}
}