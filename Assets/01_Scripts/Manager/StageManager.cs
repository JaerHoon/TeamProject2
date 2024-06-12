using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField]
    List<StageData> stageDatas = new List<StageData>();
    [SerializeField]
    List<Vector3> SpawnPos = new List<Vector3>();

    List<GameObject> Monsters = new List<GameObject>();

    GameObject NPCPlatform;
    NPCMage npcMage;
    NextStagePortal nextStagePortal;

    [SerializeField]
    GameObject ChoicePlatforms;

    GameObject skill_NormalATK;
    SkillChoiceController normalController;

    GameObject skill_SkillATK;
    SkillChoiceController skillController;

    GameObject itemRelicATK;
    SkillChoiceController itemRelicController;

    public int currentStageNum;

    private void Start()
    {
        NPCPlatform = GameObject.Find("NPCPlatform");
        npcMage = GameObject.FindFirstObjectByType<NPCMage>();
        nextStagePortal = GameObject.FindFirstObjectByType<NextStagePortal>();
        skill_NormalATK = ChoicePlatforms.transform.GetChild(0).gameObject;
        skill_SkillATK = ChoicePlatforms.transform.GetChild(1).gameObject;
        itemRelicATK = ChoicePlatforms.transform.GetChild(2).gameObject;
        normalController = skill_NormalATK.GetComponent<SkillChoiceController>();
        skillController = skill_SkillATK.GetComponent<SkillChoiceController>();
        itemRelicController = itemRelicATK.GetComponent<SkillChoiceController>();
    }

    public void SetStage(int stageNum)
    {
        //페이드인 페이드 아웃

        currentStageNum = stageNum;

        if (stageDatas[stageNum].stageType == StageData.StageType.Start)
        {
            NPCPlatform.SetActive(true);
            npcMage.gameObject.SetActive(true);
            npcMage.stageType = NPCMage.StageType.Start;
            nextStagePortal.gameObject.SetActive(true);

        }
        else if (stageDatas[stageNum].stageType == StageData.StageType.Market)
        {
            NPCPlatform.SetActive(true);
            npcMage.gameObject.SetActive(true);
            npcMage.stageType = NPCMage.StageType.Market;
            itemRelicATK.SetActive(true);
            itemRelicController.stageType = SkillChoiceController.StageType.Maerket;
            nextStagePortal.gameObject.SetActive(true);
        }
        else
        {
            SpawnMonsters(currentStageNum);
        }
    }

    void SpawnMonsters(int stageNum)
    {
        Monsters.Clear();


        for (int a = 0; a < stageDatas[stageNum].MinionCount; a++)
        {
            GameObject mon = PoolFactroy.instance.GetPool(Consts.MonsterMinion);
            Monsters.Add(mon);
        }
        for (int a = 0; a < stageDatas[stageNum].WarriorCount; a++)
        {
            GameObject mon = PoolFactroy.instance.GetPool(Consts.MonsterWarrior);
            Monsters.Add(mon);
        }

        for (int a = 0; a < stageDatas[stageNum].MageCount; a++)
        {
            GameObject mon = PoolFactroy.instance.GetPool(Consts.MonsterMage);
            Monsters.Add(mon);
        }

        for (int a = 0; a < stageDatas[stageNum].RogueCount; a++)
        {
            GameObject mon = PoolFactroy.instance.GetPool(Consts.MonsterRogue);
            Monsters.Add(mon);
        }
        for (int a = 0; a < stageDatas[stageNum].GolemCount; a++)
        {
            GameObject mon = PoolFactroy.instance.GetPool(Consts.StoneGolem);
            Monsters.Add(mon);
        }

        int[] num = RandomNumber.RandomCreate(stageDatas[stageNum].MonsterCount(), 0, SpawnPos.Count);

        for (int i = 0; i < num.Length; i++)
        {
            Monsters[i].transform.position = SpawnPos[num[i]];
        }

        PlayerReady();
    }

    void PlayerReady()
    {

    }

    public void MonsterDie(GameObject Monster)
    {
        Monsters.Remove(Monster);
        if (Monsters.Count <= 0)
        {
            WinBattle();
        }
    }

    void WinBattle()
    {
        if(stageDatas[currentStageNum].stageType == StageData.StageType.NormalATK)
        {
            normalController.Setting();
            skill_NormalATK.SetActive(true);
        }
        else if(stageDatas[currentStageNum].stageType == StageData.StageType.NormalATK)
        {
            skillController.Setting();
            skill_SkillATK.SetActive(true);
        }
        else if(stageDatas[currentStageNum].stageType == StageData.StageType.ItemRelic)
        {
            itemRelicController.Setting();
            itemRelicATK.SetActive(true);
        }

        nextStagePortal.gameObject.SetActive(true);
    }

    public void PlayerDie()
    {

    }

}
