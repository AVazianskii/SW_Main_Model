using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SW_Character_creation;

namespace Character_design
{
    public class Main_model : BaseViewModel_2
    {
        //private static Main_model instance;

        public Race__manager Race_Manager;
        public Age_status_manager Age_status_Manager;
        public Attribute_manager Attribute_Manager;
        public Skill_manager Skill_Manager;
        public Range_manager Range_Manager;
        public Force_skill_manager Force_skill_Manager;
        public Combat_ability_manager Combat_ability_Manager;
        public Force_ability_manager Force_ability_Manager;
        public Feature_manager Feature_Manager;


        /*
        public static Main_model GetInstance()
        {
            if (instance == null)
            {
                instance = new Main_model();
            }
            return instance;
        }
        public static void OverWriteInstance()
        {
            if (instance != null)
            {

                Race__manager.OverWriteInstance();
                Skill_manager.OverWriteInstance();
                Range_manager.OverWriteInstance();
                Age_status_manager.OverWriteInstance();
                Attribute_manager.OverWriteInstance();
                Force_skill_manager.OverWriteInstance();
                Combat_ability_manager.OverWriteInstance();
                Force_skill_manager.OverWriteInstance();
                Feature_manager.OverWriteInstance();

                instance = new Main_model();
            }
        } 
        public void Download_all()
        {
            ParallelLoopResult result = Parallel.ForEach<Abstract_manager>(
                new List<Abstract_manager>() 
                {
                    Race_Manager,
                    Skill_Manager,
                    Range_Manager,
                    Age_status_Manager,
                    Attribute_Manager,
                    Force_skill_Manager,
                    Combat_ability_Manager,
                    Force_ability_Manager,
                    Feature_Manager
                },
                Load_all_from
                );
        }
        */
        public void Download_all()
        {
            Load_all_from(Race_Manager);
            Load_all_from(Range_Manager);
            Load_all_from(Age_status_Manager);
            Load_all_from(Skill_Manager);
            Load_all_from(Attribute_Manager);
            Load_all_from(Force_skill_Manager);
            Load_all_from(Combat_ability_Manager);
            Load_all_from(Force_ability_Manager);
            Load_all_from(Feature_Manager); // Load_async
        }


        public Main_model()
        {
            Race_Manager            = new Race__manager ();
            Skill_Manager           = new Skill_manager();
            Range_Manager           = new Range_manager();
            Age_status_Manager      = new Age_status_manager();
            Attribute_Manager       = new Attribute_manager();
            Force_skill_Manager     = new Force_skill_manager();
            Combat_ability_Manager  = new Combat_ability_manager();
            Force_ability_Manager   = new Force_ability_manager();
            Feature_Manager         = new Feature_manager();
        }



        private void Load_all_from(Abstract_manager Manager)
        {
            Manager.Run_download_and_upload_process();
        }
        private async void Load_async(Abstract_manager _Manager_1)
        {
            await Task.Run(() => Load_all_from(_Manager_1));
        }
    }
}
