import requests
import time

def robot_go_to(linear, angular, duration):
  url_robot = "https://hackathon.tim.it/CRI1/command"

  payload_robot = "{\"command\": {\"code\": 0,\"parameters\": { \"velocity\": {\"linear\": "+str(linear)+",\"angular\": "+str(angular)+",\"duration\": "+str(duration)+"}}}}"
  headers_robot = {
    'apikey': 'RIMOSSA_COME_RICHIESTO_DAL_REGOLAMENTO',
    'Content-Type': 'application/json'
  }
  print("INSERIRE API PER ACCEDERE AL BACKEND TIM E CANCELLARE QUESTO WARNING")

  response = requests.request("POST", url_robot, headers=headers_robot, data = payload_robot)

  print(response.text.encode('utf8'))

url = "https://hackathon.tim.it/peddetect/detect"

foto_webcam = open('./test1.jpg', 'rb').read()
foto_webcam_simulata = open('./test1.jpg', 'rb').read() # todo: caricare foto da webcam raspberry con mjpg-streamer

headers = {
  'apikey': 'RIMOSSO_COME_RICHIESTO',
  'Content-Type': 'image/*'
}

# analizzo foto da hard disk
risposta_foto = requests.request("POST", url, headers=headers, data = foto_webcam)

#print(risposta_foto.text.encode('utf8'))
json_risposta1 = risposta_foto.json()

print("Persone rilevate in zona 1: " + str(len(json_risposta1['people'])))

time.sleep(3) # limite utilizzo api per secondo
# analizzo foto da webcam
risposta_webcam = requests.request("POST", url, headers=headers, data = foto_webcam_simulata)

#print(risposta_webcam.text.encode('utf8'))
json_risposta2 = risposta_webcam.json()

print("Persone rilevate in zona 2: " + str(len(json_risposta2['people'])))

if str(len(json_risposta1['people'])) >= str(len(json_risposta2['people'])):
  print("ci sono più persone nella zona 1, il robot si dirigerà li")
  robot_go_to(0.5, -0.5, 0.5)
else:
  print("ci sono più persone nella zona 2, il robot si dirigerà li")
  robot_go_to(0.5, 0.5, 0.5)

