using System;
namespace ProjectFall2020
{
    class EventManager
    {
        private static int currentEventId;
        private int maxEvents;
        private int numEvents;
        private Event[] eventList;

        public EventManager(int idSeed, int max)
        {
            currentEventId = idSeed;
            maxEvents = max;
            numEvents = 0;
            eventList = new Event[maxEvents];
        }

        public bool addEvent(string name, string venue, Date eventDate, int maxAttendees)
        {
            if (numEvents >= maxEvents) { return false; }
            Event e = new Event(currentEventId, name, venue, eventDate, maxAttendees);
            eventList[numEvents] = e;
            numEvents++;
            currentEventId++;
            return true;
        }

        private int findEvent(int eid)
        {
            for (int x = 0; x < numEvents; x++)
            {
                if (eventList[x].getEventId() == eid)
                    return x;
            }
            return -1;
        }

        public bool eventExists(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            return true;
        }

        public Event getEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return null; }
            return eventList[loc];
        }

        public bool deleteEvent(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return false; }
            eventList[loc] = eventList[numEvents - 1];
            numEvents--;
            return true;
        }
        public string getEventInfo(int eid)
        {
            int loc = findEvent(eid);
            if (loc == -1) { return "There is no event with id " + eid + "."; }
            return eventList[loc].ToString();
        }
        public string getEventList()
        {
            string s = "Event List:";
            for (int x = 0; x < numEvents; x++)
            {
                s = s + "\n" + eventList[x].getEventId() + " \t " + eventList[x].getEventName() + " \t " + eventList[x].getVenue();
            }
            return s;
        }

        //MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: addAtendee()

        public bool addAtendee(int eid, Customer c) // register customer for the event and check if the event is not full.
        {
                return getEvent(eid).addAttendee(c);
        }

        // MODIFICATION (OLEKSII PEDKO) – IMPLEMENTED METHODS: isAlreadyRegistered()

        public bool isAlreadyRegistered(int eid, int cid) // check whether customer is already registered or not.
        {
            return getEvent(eid).isAlreadyRegistered(cid);
        }

        // MODIFICATION (ALEKSANDR KUDIN) – IMPLEMENTED METHODS: removeAllCustomerAttendees()

        public void removeAllCustomerAttendees(int cid) // removing all customer's attendees.
        {
            for (int i =  0;  i < numEvents; i++)
            {
                eventList[i].removeAttendee(cid);
            }
        }

    }


}
