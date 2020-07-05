//
//  SecondViewController.swift
//  telecomando_robot
//
//  Created by Roberto D'Isanto on 02/07/2020.
//  Copyright © 2020 Roberto D'Isanto. All rights reserved.
//

import UIKit

class SecondViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view.
    }

    @IBOutlet weak var textViewOut1: UITextView!
    
    @IBAction func btnSuVeloce(_ sender: Any) {
        muoviRobot(linear: 0.5, angular: 0, duration: 2.0)
    }
    
    @IBAction func btnSu(_ sender: Any) {
        muoviRobot(linear: 0.25, angular: 0, duration: 2.0)
    }
    
    @IBAction func btnGiuVeloce(_ sender: Any) {
        muoviRobot(linear: -0.5, angular: 0, duration: 2.0)
    }
    
    @IBAction func btnGiu(_ sender: Any) {
        muoviRobot(linear: -0.25, angular: 0, duration: 2.0)
    }
    
    @IBAction func btnDestra(_ sender: Any) {
        muoviRobot(linear: 0.0, angular: 0.5, duration: 2.0)
    }
    
    @IBAction func btnSinistra(_ sender: Any) {
        muoviRobot(linear: 0.0, angular: -0.5, duration: 2.0)
    }
    
    @IBAction func btnNE(_ sender: Any) {
        muoviRobot(linear: 0.5, angular: -0.5, duration: 2.0)
    }
    
    @IBAction func btnNO(_ sender: Any) {
        muoviRobot(linear: 0.5, angular: 0.5, duration: 2.0)
    }
    
    @IBAction func btnSE(_ sender: Any) {
        muoviRobot(linear: -0.5, angular: -0.5, duration: 2.0)
    }
    
    @IBAction func btnSO(_ sender: Any) {
        muoviRobot(linear: -0.5, angular: 0.5, duration: 2.0)
    }
    
    func muoviRobot(linear: Float, angular: Float, duration: Float){
        var semaphore = DispatchSemaphore (value: 0)

        let parameters = """
        {
            "command": {
                "code": 0,
                "parameters": {
                    "velocity": {
                        "linear": \(linear),
                        "angular": \(angular),
                        "duration": \(duration)
                    }
                }
            }
        }
        """
        let postData = parameters.data(using: .utf8)

        var request = URLRequest(url: URL(string: "https://hackathon.tim.it/CRI1/command")!,timeoutInterval: Double.infinity)
        request.addValue("RIMOSSO_COME_RICHIESTO", forHTTPHeaderField: "apikey")
        print("INSERIRE API PER BACKEND TIM!");
        request.addValue("application/json", forHTTPHeaderField: "Content-Type")

        request.httpMethod = "POST"
        request.httpBody = postData

        let task = URLSession.shared.dataTask(with: request) { data, response, error in
          guard let data = data else {
            print(String(describing: error))
            return
          }
          print(String(data: data, encoding: .utf8)!)
            DispatchQueue.main.async { // Correct
               self.textViewOut1.text = String(data: data, encoding: .utf8)! + parameters
            }

          semaphore.signal()
        }

        task.resume()
        semaphore.wait()

    }
}

