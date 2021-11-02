using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundThrow : MonoBehaviour
{
	public GameObject ballObj;             // ����������Prefab
	private Vector3 clickPos;             // �N���b�N�����ʒu���W�i���A���A���j
	public float speed;                     //    ��΂��͂̑傫���̒l�ł� 
	public Transform canonPos;  //�@ �e���o��ꏊ�̍��W


	void Update()            //�@���t���[�����ƂɁA�N���b�N����Ă邩�`�F�b�N���܂�
	{
		if (Input.GetMouseButtonDown(0))        // �����}�E�X�ō��N���b�N("0"�����N���b�N�ɏ����ݒ肵�Ă���܂�)������E�E
		{
			{
				clickPos = Input.mousePosition;          // Vector3�Ń}�E�X���N���b�N�����ʒu���W���擾����
				Debug.Log(clickPos);                              //�f�o�b�O�F�@Z���̒l���O���ƕ\������܂���A�iScreenToWorldPoint�ɕK�v�j
				clickPos.z = 10.0f;             // �����łɓK���Ȓl��z�l�ɓ���܂�

				Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(clickPos);
				//Instantiate �I�u�W�F�N�g�����֐��i �I�u�W�F�N�g��(GameObject), ���ʒu(Vector3), �I�u�W�F�N�g�̊p�x(Quaternion)�j
				GameObject ball = Instantiate(ballObj, canonPos.position, ballObj.transform.rotation);
				//�e�̔�ԕ����x�N�g��bulletDir�ɁA�e�̏o��canonPos�̈ʒu�ƃ}�E�X�̃N���b�N�����ʒu�������Z�����l�ɁA
				//(1,1,0)�������āiScale�j�AZ���̒l��0�ɂ��܂��A�����normalized�Łu�P�ʃx�N�g���v�ɒ����܂�
				Vector3 bulletDir = Vector3.Scale((mouseWorldPos - canonPos.position), new Vector3(1, 1, 0)).normalized;
				ball.GetComponent<Rigidbody2D>().AddForce(bulletDir * speed); //AddForce��rigidbody��t����ball���΂��܂�

				//Instantiate�i �I�u�W�F�N�g�����֐��j �I�u�W�F�N�g��(GameObject), �ʒu(Vector3), �p�x(Quaternion)
				// ScreenToWorldPoint(�ʒu(Vector3))�F�X�N���[�����W�����[���h���W�ɕϊ�����A������J�����ʒu�ɂ���
				
			}
		}
	}
}